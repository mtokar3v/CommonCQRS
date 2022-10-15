using AutoMapper;
using CRUDUserFeature.DTOs;
using CRUDUserFeature.Queries;
using Interfaces.Repositories;
using MediatR;

namespace CRUDUserFeature
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository; 
        private readonly IMapper _mapper;
        public GetUserByIdHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.Id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
