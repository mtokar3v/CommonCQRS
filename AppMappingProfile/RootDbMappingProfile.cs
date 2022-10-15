using AutoMapper;
using CRUDUserFeature.DTOs;
using RootDb.Entities;

namespace AppMappingProfile
{
    public class RootDbMappingProfile : Profile
    {
        public RootDbMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
