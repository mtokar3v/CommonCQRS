using CRUDUserFeature.Commands;
using CRUDUserFeature.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using RootDb.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CRUDUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetUsersQuery()));

        [HttpGet("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] Guid id) => Ok(await _mediator.Send(new GetUserByIdQuery(id)));

        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpPut]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(User), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateUserEmailCommand request) => Ok(await _mediator.Send(request));
    }
}
