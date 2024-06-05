using TesteJuntoSeguros.Application.AuthenticationContext.Command;
using TesteJuntoSeguros.Domain.AuthenticationContext.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TesteJuntoSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> SignIn(AuthenticationRequestDto authenticationRequestDto)
        {
            var response = String.Empty;

            try
            {
                response = await _mediator.Send(new AuthenticationCommand(authenticationRequestDto));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Ok(response);
        }
    }
}
