using Interfaces.Repositories;
using MediatR;
using RootDb.Entities;

namespace CRUDUserFeature.Commands
{
    public class UpdateUserEmailCommand : IRequest<User>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public class UpdateUserHandler : IRequestHandler<UpdateUserEmailCommand, User>
        {
            private readonly IUserRepository _userRepository;

            public UpdateUserHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public Task<User> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
            {
                return _userRepository.UpdateUserEmailAsync(request.Id, request.Email);
            }
        }
    }
}
