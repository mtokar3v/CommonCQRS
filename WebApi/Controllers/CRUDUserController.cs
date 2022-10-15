using CRUDUserFeature.Commands;
using CRUDUserFeature.DTOs;
using CRUDUserFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            await _mediator.Send(new InsertUserCommand(user));
            return Ok();
        }
    }
}
