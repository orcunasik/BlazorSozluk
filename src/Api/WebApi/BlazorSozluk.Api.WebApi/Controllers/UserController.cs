using BlazorSozluk.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSozluk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginUserCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            Guid guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            Guid guid = await _mediator.Send(command);
            return Ok(guid);
        }
    }
}
