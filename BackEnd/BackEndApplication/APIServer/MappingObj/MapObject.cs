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
            CreateMap<JobDTO, JobDescription>();
            CreateMap<JobDescription, JobDTO>();
            CreateMap<CurriculumVitaeDTO, CurriculumVitae>();
            //CreateMap<CurriculumVitae, CurriculumVitaeDTO>()
            //    .ForMember(x => x.UserId, src => src.MapFrom(src => src.User != null ? src.User.id : 0));
        }
    }
}
