using Interfaces.Repositories;
using RootDb.Entities;
using RootDb.DataItems;

using MediatR;
using AutoMapper;

namespace CRUDUserFeature.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }

        public class CreateUserHandler : IRequestHandler<CreateUserCommand, Unit>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public CreateUserHandler(
                IUserRepository userRepository,
                IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = _mapper.Map<User>(request);
                await _userRepository.InsertUser(user);
                return Unit.Value;
            }
        }
    }
}
