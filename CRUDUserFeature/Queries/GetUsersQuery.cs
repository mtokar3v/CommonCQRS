using CRUDUserFeature.DTOs;
using MediatR;

namespace CRUDUserFeature.Queries
{
    public record GetUsersQuery : IRequest<IQueryable<UserDto>>;
}
