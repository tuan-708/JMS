using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.Models.Entity;
using AutoMapper;

namespace APIServer.MappingObj
{
    public class MapObject : Profile
    {
        public MapObject()
        {
            CreateMap<UserCreatingDTO, Recuirter>()
                .ForMember(x => x.DOB, src => src.MapFrom(src => Validation.convertDateTime(src.dobStr)));
            CreateMap<Recuirter, UserDTO>()
                .ForMember(x => x.dobStr, src => src.MapFrom(src => src.DOB.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.createdDate, src => src.MapFrom(src => src.CreatedDate.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.lastUpdate, src => src.MapFrom(src => src.LastUpdate.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.roleName, src => src.MapFrom(src => src.Role.ToString()));
            CreateMap<JobDTO, JobDescription>()
                .ForMember(x => x.EmploymentTypeId, src => src.MapFrom(src => Validation.ConvertInt(src.EmploymentTypeName) ))
                .ForMember(x => x.CategoryId, src => src.MapFrom(src => Validation.ConvertInt(src.CategoryName) ))
                .ForMember(x => x.CompanyId, src => src.MapFrom(src => Validation.ConvertInt(src.CompanyName) ))
                .ForMember(x => x.CategoryId, src => src.MapFrom(src => Validation.ConvertInt(src.CategoryName) ))
                ;
            CreateMap<JobDescription, JobDTO>()
                .ForMember(x => x.PositionTitlesName, src => src.MapFrom(src => src.PositionTitles.Select(x => x.Title).ToList()))
                .ForMember(x => x.EmploymentTypeName, src => src.MapFrom(src => src.EmploymentType.Title))
                .ForMember(x => x.CompanyName, src => src.MapFrom(src => src.Company.CompanyName))
                .ForMember(x => x.CategoryName, src => src.MapFrom(src => src.Category.CategoryName))
                ;
            CreateMap<CurriculumVitaeDTO, CurriculumVitae>()
                .ForMember(x => x.DOB, src => src.MapFrom(src => Validation.convertDateTime(src.DOB)))
                .ForMember(x => x.EmploymentTypeId, src => src.MapFrom(src => Validation.ConvertInt(src.EmploymentTypeName)))
                .ForMember(x => x.PositionTitleId, src => src.MapFrom(src => Validation.ConvertInt(src.PositionTitleName)))
                .ForMember(x => x.CategoryId, src => src.MapFrom(src => Validation.ConvertInt(src.CategoryName)))
                ;
            CreateMap<CurriculumVitae, CurriculumVitaeDTO>()
                .ForMember(x => x.EmploymentTypeName, src => src.MapFrom(src => src.EmploymentType.Title))
                .ForMember(x => x.DOB, src => src.MapFrom(src => src.DOB.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.CreatedDateDisplay, src => src.MapFrom(src => src.CreatedDate.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.LastUpdateDateDisplay, src => src.MapFrom(src => src.LastUpdateDate.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.PositionTitleName, src => src.MapFrom(src => src.PositionTitle.Title))
                .ForMember(x => x.CategoryName, src => src.MapFrom(src => src.Category.CategoryName))
                ;
            CreateMap<CVApply, CVApplyDTO>()
                .ForMember(x => x.Candidate, src => src.MapFrom(src => src.Candidate))
                .ForMember(x => x.JobDescription, src => src.MapFrom(src => src.JobDescription))
                .ForMember(x => x.PositionTitle, src => src.MapFrom(src => src.PositionTitle));


            CreateMap<Candidate, CandidateDTO>();

            CreateMap<Award, AwardDTO>();
            CreateMap<Skill, SkillDTO>();
            CreateMap<Education, EducationDTO>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<Certificate, CertificateDTO>();
            CreateMap<JobExperience, JobExperienceDTO>();

            CreateMap<AwardDTO, Award>();
            CreateMap<SkillDTO, Skill>();
            CreateMap<EducationDTO, Education>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<CertificateDTO, Certificate>();
            CreateMap<JobExperienceDTO, JobExperience>();

            CreateMap<Company, CompanyDTO>()
                .ForMember(x => x.CategoryName, src => src.MapFrom(y => y.Category.CategoryName))
                .ForMember(x => x.DateCreatedDisplay, src => src.MapFrom(y => y.DateCreated.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.RecuirterFounder, src => src.MapFrom(y => y.Recuirter.FullName))
                ;
            CreateMap<CompanyDTO, Company>()
                .ForMember(x => x.CategoryId, src => src.MapFrom(y => Validation.ConvertInt(y.CategoryName)))
                ;
            CreateMap<EmployeeInCompany, EmployeeDTO>()
                .ForMember(x => x.RecuirterName, src => src.MapFrom(y => y.Recuirter.FullName))
                .ForMember(x => x.StartDateDisplay, src => src.MapFrom(y => y.StartDate.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.EndDateDisplay, src => src.MapFrom(y => !y.EndDate.HasValue ? "Now" : y.EndDate.Value.ToString(GlobalStrings.FORMAT_DATE)))
                ;
            CreateMap<EmployeeDTO, EmployeeInCompany>()
                .ForMember(x => x.StartDate, src => src.MapFrom(y => Validation.convertDateTime(y.StartDateDisplay)))
                .ForMember(x => x.EndDate, src => src.MapFrom(y => convertDateTimeNull(y.EndDateDisplay) ))
                ;

            CreateMap<Category, CategoryDTO>()
                .ForMember(x => x.CreatedAt, src => src.MapFrom(y => y.CreatedAt.ToString(GlobalStrings.FORMAT_DATE) ))
                ;
            CreateMap<PositionTitle, PositionTitleDTO>();
            CreateMap<EmploymentType, EmploymentTypeDTO>();

            CreateMap<CategoryDTO, Category>()
                .ForMember(x => x.CreatedAt, src => src.MapFrom(y => Validation.convertDateTime(y.CreatedAt) ))
                ;
            CreateMap<PositionTitleDTO, PositionTitle>();
            CreateMap<EmploymentTypeDTO, EmploymentType>();
        }

        private DateTime? convertDateTimeNull(string? input)
        {
            if (Validation.checkStringIsEmpty(input))
            {
                return null;
            }
            else
            {
                return Validation.convertDateTime(input);
            }
        }
    }
}
