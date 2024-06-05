using TesteJuntoSeguros.Application.UserContext.Command;
using TesteJuntoSeguros.Domain.UserContext.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TesteJuntoSeguros.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [Route("authenticated")]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto user)
        {
            UserDto? response;

            if (user == null)
            {
                Serilog.Log.Information($"Sem dados: {user}");
                return NotFound();
            }
                

            user.HttpAction = "Create";

            try
            {
                response = await _mediator.Send(new UserCommand(user));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto user)
        {
            UserDto? response;

            if (user == null)
                return NotFound();

            user.HttpAction = "Update";

            try
            {
                response = await _mediator.Send(new UserCommand(user));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Accepted(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            UserDto? user = new UserDto
            {
                Id = id
            };

            if (user == null)
                return NotFound();

            user.HttpAction = "Delete";

            try
            {
                await _mediator.Send(new UserCommand(user));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Accepted();
        }

        [HttpGet("Users/{id}")]
        public async Task<IActionResult> GetUsersById(string id)
        {
            var user = User;

            if(user?.Identity?.IsAuthenticated ?? false)
            {
                UserDto? userDto = new UserDto
                {
                    Id = id
                };

                if (userDto == null)
                    return NotFound();

                userDto.HttpAction = "Get";

                try
                {
                    userDto = await _mediator.Send(new UserCommand(userDto));
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }

                return Ok(userDto);
            }

            return Unauthorized();
        }
    }
}
