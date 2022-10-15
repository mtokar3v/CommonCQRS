using CRUDUserFeature.DTOs;
using MediatR;

namespace CRUDUserFeature.Queries
{
    public record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;
}
