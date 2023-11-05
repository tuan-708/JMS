using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.DTO.ResponseBody;
using APIServer.IRepositories;
using APIServer.IServices;
using APIServer.Models.Entity;
using AutoMapper;
using X.PagedList;

namespace APIServer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IBaseRepository<Company> _companyRepository;
        private readonly IRecuirterRepository _recuirterRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IBaseRepository<EmployeeInCompany> _empRepo;

        public CompanyService(IBaseRepository<Company> companyRepository, IRecuirterRepository recuirterRepository, IMapper mapper, IConfiguration configuration, IBaseRepository<EmployeeInCompany> empRepo)
        {
            _companyRepository = companyRepository;
            _recuirterRepository = recuirterRepository;
            _mapper = mapper;
            _configuration = configuration;
            _empRepo = empRepo;
        }

        public int AddEmployeeInCompany(int recuirterId, int companyId, EmployeeDTO employee)
        {
            if (companyId <= 0 || employee.RecuirterId == null)
                throw new Exception("Not found");
            var com = _companyRepository.GetById(companyId);
            if (com == null)
                throw new Exception("Not found");
            if (com.RecuirterId != recuirterId)
                throw new Exception("Permission denied");
            var rec = _recuirterRepository.GetById((int)employee.RecuirterId);
            if (rec == null)
                throw new Exception("Not found");
            var emp = _mapper.Map<EmployeeInCompany>(employee);
            emp.CompanyId = companyId;
            emp.RecuirterId = rec.Id;
            return _empRepo.Create(emp) + _companyRepository.Update(com);
        }

        public int Create(CompanyDTO data)
        {
            throw new NotImplementedException();
        }

        public int CreateById(CompanyDTO data, int id)
        {
            if (_companyRepository.GetAll().Any(x => x.RecuirterId == id))
            {
                throw new Exception("This recuirter already create a company");
            }
            if (id <= 0 || data == null)
            {
                throw new Exception("data not valid");
            }
            var rec = _recuirterRepository.GetById(id);
            if (rec == null)
            {
                throw new Exception("Recuirter not exist");
            }
            var com = _mapper.Map<Company>(data);
            if (com.YearOfEstablishment <= 1000 || com.YearOfEstablishment > DateTime.Now.Year)
                throw new Exception("Year Of Establishment must > 1000");
            if (Validation.checkStringIsEmpty(com.CompanyName, com.Email, com.Phone, com.Address, com.Tax))
            {
                throw new Exception("data not valid");
            }
            if (!Validation.IsPhoneNumberValid(com.Phone))
                throw new Exception("data phone not valid");
            var listEmp = new List<EmployeeInCompany>();
            if (data.RecuirtersInCompany.Any())
            {
                foreach (var o in data.RecuirtersInCompany)
                {
                    var re = _recuirterRepository.GetById((int)o.RecuirterId);
                    if (re == null)
                        throw new Exception("Employee in company not exist");
                    var emp = _mapper.Map<EmployeeInCompany>(o);
                    emp.CompanyId = com.CompanyId;
                    if (emp.IsWorking)
                        emp.EndDate = null;
                    if (emp.IsWorking && emp.EndDate == null)
                        throw new Exception("Employee information not correct at working information");
                    listEmp.Add(emp);
                }
            }
            com.EmployeeInCompanies = listEmp;
            com.RecuirterId = id;
            com.JobDescriptions = null;
            com.IsDelete = false;
            com.DateCreated = DateTime.Now;
            com.AvatarURL = null;
            com.BackGroundURL = null;
            return _companyRepository.CreateById(com, id);
        }

        public int Delete(CompanyDTO data)
        {
            throw new NotImplementedException();
        }

        public int DeleteByRecuirterId(int recuirterId, int companyId)
        {
            if (recuirterId <= 0 || companyId <= 0)
                throw new Exception("Data not valid");
            var com = _companyRepository.GetById(companyId);
            if (com == null)
                throw new Exception("Not found");
            if (com.RecuirterId != recuirterId)
                throw new Exception("Permission denied");
            com.IsDelete = true;
            return _companyRepository.Update(com);
        }

        public int DeleteEmployeeInCompany(int recuirterId, int companyId, int employeeId)
        {
            if (companyId <= 0)
                throw new Exception("Not found");
            var com = _companyRepository.GetById(companyId);
            if (com == null || !com.EmployeeInCompanies.Any())
                throw new Exception("Not found");
            if (recuirterId != com.RecuirterId)
                throw new Exception("Permisson denied");
            var rec = _empRepo.GetById(employeeId);
            if (rec == null)
                throw new Exception("Not found");
            return _empRepo.Delete(employeeId) + _companyRepository.Update(com);
        }

        public List<CompanyDTO> getAll()
        {
            var data = _companyRepository.GetAll();
            var rs = _mapper.Map<List<CompanyDTO>>(data);
            for (int i = 0; i < data.Count; i++)
            {
                var emp = data[i].EmployeeInCompanies;
                rs[i].RecuirtersInCompany = _mapper.Map<List<EmployeeDTO>>(emp);
            }
            return rs;
        }

        public List<CompanyDTO> getAllById(int id)
        {
            if (id <= 0)
                throw new Exception("Recuirter not exist");
            return null;
        }

        public List<CompanyDTO> GetAllByName(string? search)
        {
            if (Validation.checkStringIsEmpty(search))
                return getAll();
            var data = _companyRepository.GetAll()
                .Where(x => x.CompanyName.ToLower().Contains(search.ToLower()) ||
                x.Recuirter.FullName.ToLower().Contains(search.ToLower()) ||
                x.Recuirter.PhoneNumber.ToLower().Contains(search.ToLower()))
                .ToList();
            var rs = _mapper.Map<List<CompanyDTO>>(data);
            for (int i = 0; i < data.Count; i++)
            {
                var emp = data[i].EmployeeInCompanies;
                rs[i].RecuirtersInCompany = _mapper.Map<List<EmployeeDTO>>(emp);
            }
            return _mapper.Map<List<CompanyDTO>>(rs);
        }

        public CompanyDTO? GetById(int id)
        {
            var data = _companyRepository.GetById(id);
            if (data == null)
                throw new Exception("Not found");
            var rs = _mapper.Map<CompanyDTO>(data);
            rs.RecuirtersInCompany = _mapper.Map<List<EmployeeDTO>>(data.EmployeeInCompanies);
            return rs;
        }

        public PagingResponseBody<List<CompanyDTO>> GetListPaging(int? page, List<CompanyDTO> listData)
        {
            //var abc = new Paging<CompanyDTO>(_configuration);
            //return abc.PagingObject(listData, page);
            var k = listData.Count;
            if (k == 0)
            {
                return new PagingResponseBody<List<CompanyDTO>>
                {
                    message = GlobalStrings.SUCCESSFULLY,
                    statusCode = System.Net.HttpStatusCode.OK,
                };
            }
            var numberInOnePage = int.Parse(_configuration["PageSize"]);
            var totalPage = (int)Math.Ceiling((decimal)k / numberInOnePage);
            page = page <= 0 || page == null ? 1 : page;
            page = page > totalPage ? totalPage : page;
            var rs = listData.ToPagedList((int)page, numberInOnePage).ToList();
            return new PagingResponseBody<List<CompanyDTO>>
            {
                currentPage = (int)page,
                message = GlobalStrings.SUCCESSFULLY,
                data = rs,
                ObjectLength = k,
                statusCode = System.Net.HttpStatusCode.OK,
                TotalPage = totalPage,
            };
        }

        public int Update(CompanyDTO data)
        {
            throw new NotImplementedException();
        }

        public int UpdateByRecuirterId(CompanyDTO data, int recuirterId)
        {
            var com = _companyRepository.GetById(data.CompanyId);
            if (com == null)
                throw new Exception("Not found");
            if (com.RecuirterId != recuirterId || com.EmployeeInCompanies.Any(x => x.RecuirterId == recuirterId))
            {
                throw new Exception("Permission denied");
            }
            var input = _mapper.Map<Company>(data);
            if (input.YearOfEstablishment <= 1000 || com.YearOfEstablishment > DateTime.Now.Year)
                throw new Exception("Year Of Establishment must > 1000");
            if (Validation.checkStringIsEmpty(input.CompanyName, input.Email,
                input.Phone, input.Address, input.Tax))
            {
                throw new Exception("data not valid");
            }

            com.Tax = input.Tax;
            com.YearOfEstablishment = input.YearOfEstablishment;
            com.CompanyName = input.CompanyName;
            com.Email = input.Email;
            com.Phone = input.Phone;
            com.Address = input.Address;
            com.Description = input.Description;
            com.WebURL = input.WebURL;
            com.CategoryId = input.CategoryId;
            com.Size = input.Size;

            return _companyRepository.Update(com);
        }

        public int UpdateEmployeeInCompany(int recuirterId, int companyId, EmployeeDTO employee)
        {
            if (companyId <= 0 || employee.RecuirterId == null)
                throw new Exception("Not found");
            var com = _companyRepository.GetById(companyId);
            if (com == null)
                throw new Exception("Not found");
            if (com.RecuirterId != recuirterId && !com.EmployeeInCompanies
                .Any(x => x.RecuirterId == recuirterId))
                throw new Exception("Permission denied");
            var rec = _recuirterRepository.GetById((int)employee.RecuirterId);
            if (rec == null)
                throw new Exception("Not found");
            var emp = _mapper.Map<EmployeeInCompany>(employee);
            emp.CompanyId = companyId;
            emp.RecuirterId = rec.Id;
            return _empRepo.Update(emp);
        }
    }
}
