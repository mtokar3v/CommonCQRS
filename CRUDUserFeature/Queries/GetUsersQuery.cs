using Interfaces.Repositories;
using MediatR;
using AutoMapper;
using RootDb.Entities;

namespace CRUDUserFeature.Queries
{
    public class GetUsersQuery : IRequest<IQueryable<User>>
    {
        public class GetUsersHandler : IRequestHandler<GetUsersQuery, IQueryable<User>>
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

            public Task<IQueryable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                var users = _userRepository
                                .GetUsers()
                                .Select(u => _mapper.Map<User>(u));

                return Task.FromResult(users);
            }
        }
    }
}
