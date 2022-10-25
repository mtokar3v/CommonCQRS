using AutoMapper;
using CRUDUserFeature.Commands;
using RootDb.Entities;

namespace AppMappingProfile
{
    public class RootDbMappingProfile : Profile
    {
        public RootDbMappingProfile()
        {
            CreateMap<User, CreateUserCommand>();
        }
    }
}
