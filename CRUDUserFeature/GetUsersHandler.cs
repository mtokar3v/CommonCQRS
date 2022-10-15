using AutoMapper;
using CRUDUserFeature.DTOs;
using CRUDUserFeature.Queries;
using Interfaces.Repositories;
using MediatR;

namespace CRUDUserFeature
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IQueryable<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUsersHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<IQueryable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository
                            .GetUsers()
                            .Select(u => _mapper.Map<UserDto>(u));

            return Task.FromResult(users);
        }
    }
}
