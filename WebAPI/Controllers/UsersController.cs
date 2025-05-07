using MediatR;
using Microsoft.AspNetCore.Mvc;
using PromomashTest.Application.Queries;

namespace PromomashTest.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            try
            {
                var userId = await _mediator.Send(command);
                return Ok(new { message = "User registered", userId });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
