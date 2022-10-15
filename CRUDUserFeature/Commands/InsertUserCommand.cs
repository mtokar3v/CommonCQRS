using CRUDUserFeature.DTOs;
using MediatR;

namespace CRUDUserFeature.Commands
{
    public record InsertUserCommand(UserDto User) : IRequest;
}
