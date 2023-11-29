using APIServer.IRepositories;
using APIServer.Models;
using APIServer.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIServer.Repositories
{
    public class RecuirterRepository : IRecuirterRepository
    {
        public JMSDBContext context { get; set; }

        public RecuirterRepository(JMSDBContext context)
        {
            this.context = context;
        }

        public bool checkExistUserNameEmail(string username, string email)
        {
            var data = context.Recuirters
                .Where(x => x.UserName.ToLower() == username.ToLower()
                && x.Email.ToLower() == email.ToLower()).ToArray();
            return data.Length > 0;
        }

        public int Create(Recuirter data)
        {
            context.Recuirters.Add(data);
            return context.SaveChanges();
        }

        public int CreateById(Recuirter data, int? id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            var data = context.Recuirters
                .FirstOrDefault(x => x.Id == id && !x.IsDelete);
            if (data == null)
            {
                throw new NullReferenceException("Recuirter not exist");
            }
            data.IsDelete = true;
            context.Recuirters.Update(data);
            return context.SaveChanges();
        }

        public Recuirter findByUserName(string? username)
        {
            return context.Recuirters
                .FirstOrDefault(x => x.UserName.ToLower() == username.ToLower());
        }

        public List<Recuirter> GetAll()
        {
            var rs = context.Recuirters
                .Include(x => x.Role)
                .Include(x => x.EmployeeInCompanies)
                .Include(x => x.Company)
                .Where(x => x.IsDelete == false)
                .ToList();
            return rs;
        }

        public List<Recuirter> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public Recuirter GetById(int id)
        {
            var rs = context.Recuirters
                .Include(x => x.Role)
                .Include(x => x.EmployeeInCompanies)
                .Include(x => x.Company)
                .FirstOrDefault(x => !x.IsDelete && x.Id == id);
            return rs;
        }

        public Recuirter Login(string? username, string? password)
        {
            var data = context.Recuirters
                .FirstOrDefault(x => x.UserName.ToLower() == username.ToLower());
            if (VerifyPassword(password, data.Password))
                return data;
            return null;
        }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public bool IsEmailExist(string email)
        {
            Recuirter recuirter = context.Recuirters.FirstOrDefault(x => x.Email.Trim().Equals(email.Trim()));
            return recuirter != null;
        }

        public int Update(Recuirter data)
        {
            context.Recuirters.Update(data);
            return context.SaveChanges();
        }

        public bool checkExistById(int? recuirterId)
        {
            return context.Recuirters.Where(x => x.Id == recuirterId).Any();
        }

        public int UpdatePassword(string email, string password)
        {
            Recuirter recruiter = context.Recuirters.FirstOrDefault(x => x.Email.Equals(email));
            if (recruiter != null)
            {
                string hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
                recruiter.Password = hashPassword;
                return context.SaveChanges();
            }
            return 0;
        }

        public int Register(string email, string fullName, string username, string password)
        {
            Recuirter recuirter = new Recuirter();
            string hashPassword = BCrypt.Net.BCrypt.HashPassword(password.Trim());
            recuirter.Email = email.Trim();
            recuirter.Password = hashPassword;
            recuirter.FullName = fullName.Trim();
            recuirter.UserName = username.Trim();
            recuirter.CreatedDate = DateTime.Now;
            recuirter.PhoneNumber = "";
            recuirter.IsActive = true;
            recuirter.IsDelete = false;
            context.Recuirters.Add(recuirter);
            return context.SaveChanges();
        }

        public bool IsUsernameExist(string username)
        {
            Recuirter recuirter = context.Recuirters.FirstOrDefault(x => x.UserName.Trim().Equals(username.Trim()));
            return recuirter != null;
        }

        private int CalculateAge(DateTime dob)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - dob.Year;

            // Kiểm tra xem đã qua sinh nhật chưa trong năm nay
            if (currentDate.Month < dob.Month || (currentDate.Month == dob.Month && currentDate.Day < dob.Day))
            {
                age--;
            }

            return age;
        }

        public int UpdateProfile(int recruiterId, string fullName, string phoneNumber, DateTime DOB, int genderId, string description)
        {
            Recuirter recruiter = context.Recuirters.FirstOrDefault(x => x.Id == recruiterId);
            if (recruiter != null)
            {
                recruiter.FullName = fullName.Trim();
                recruiter.PhoneNumber = phoneNumber.Trim();
                if (DOB != null && CalculateAge(DOB) >= 18 && CalculateAge(DOB) < 100)
                    recruiter.DOB = DOB;
                else throw new Exception("DOB not valid");
                recruiter.GenderId = genderId;
                recruiter.Description = description;
                recruiter.LastUpdate = DateTime.Now;
                return context.SaveChanges();
            }
            return 0;
        }

        public int UpdatePassword(int recruiterId, string newPassword)
        {
            Recuirter recruiter = context.Recuirters.FirstOrDefault(x => x.Id == recruiterId);
            if (recruiter != null)
            {
                string hashPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                recruiter.Password = hashPassword;
                return context.SaveChanges();
            }
            return 0;
        }
    }
}
