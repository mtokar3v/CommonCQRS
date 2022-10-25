using Interfaces.Repositories;
using MediatR;
using RootDb.Entities;
using System.Data.Entity.Core;
using Constants;

namespace CRUDUserFeature.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; }

        public GetUserByIdQuery(Guid Id)
        {
            this.Id = Id;
        }

        public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
        {
            private readonly IUserRepository _userRepository;

            public GetUserByIdHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var key = request.Id;

                var user = await _userRepository.GetUserAsync(key);
                if (user is null) throw new ObjectNotFoundException(Failed.ToFindUser(key));

                return user;
            }
        }
    }
}
