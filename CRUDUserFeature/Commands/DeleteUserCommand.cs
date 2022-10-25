using Interfaces.Repositories;
using MediatR;

namespace CRUDUserFeature.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
        {
            private readonly IUserRepository _userRepository;

            public DeleteUserHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                await _userRepository.DeleteUserAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
