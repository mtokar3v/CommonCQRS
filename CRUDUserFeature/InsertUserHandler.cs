using AutoMapper;
using CRUDUserFeature.Commands;
using Interfaces.Repositories;
using MediatR;
using RootDb.Entities;

namespace CRUDUserFeature
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public InsertUserHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.User);
            await _userRepository.InsertUser(user);

            return Unit.Value;
        }
    }
}
