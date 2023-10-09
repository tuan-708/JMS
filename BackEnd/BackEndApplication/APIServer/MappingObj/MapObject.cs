﻿using APIServer.Common;
using APIServer.DTO.EntityDTO;
using APIServer.Models.Entity;
using AutoMapper;

namespace APIServer.MappingObj
{
    public class MapObject : Profile
    {
        public MapObject()
        {
            CreateMap<UserCreatingDTO, User>()
                .ForMember(x => x.dob, src => src.MapFrom(src => Validation.convertDateTime(src.dobStr)));
            CreateMap<User, UserDTO>()
                .ForMember(x => x.dobStr, src => src.MapFrom(src => src.dob.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.createdDate, src => src.MapFrom(src => src.createdDate.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.lastUpdate, src => src.MapFrom(src => src.lastUpdate.ToString(GlobalStrings.FORMAT_DATE)))
                .ForMember(x => x.roleName, src => src.MapFrom(src => src.role.ToString()));
            CreateMap<JobDTO, JobPost>();
            CreateMap<JobPost, JobDTO>()
                .ForMember(x => x.status, src => src.MapFrom(src => src.status.ToString()));
            CreateMap<CurriculumVitaeDTO, CurriculumVitae>()
                .ForMember(x => x.DOB, src => src.MapFrom(src => Validation.convertDateTime(src.DOB)));
            CreateMap<CurriculumVitae, CurriculumVitaeDTO>()
                .ForMember(x => x.UserId, src => src.MapFrom(src => src.User != null ? src.User.id : 0));
        }
    }
}
