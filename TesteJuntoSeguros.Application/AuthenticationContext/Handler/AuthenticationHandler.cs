using TesteJuntoSeguros.Application.AuthenticationContext.Command;
using TesteJuntoSeguros.Application.UserContext.Util;
using TesteJuntoSeguros.Domain.AuthenticationContext.Interface;
using TesteJuntoSeguros.Domain.AuthenticationContext.Request;
using MediatR;

namespace TesteJuntoSeguros.Application.AuthenticationContext.Handler
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationCommand, string?>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<string?> Handle(AuthenticationCommand authenticationCommand, CancellationToken cancellationToken)
        {
            var authenticationRequest = new AuthenticationRequest{
                Login = authenticationCommand.AuthenticationRequestDto.Login,
                Password = Utils.Encrypt(authenticationCommand.AuthenticationRequestDto.Password)
            };

            var user = _authenticationRepository.SignInByLogin(authenticationRequest);
            return await Task.FromResult(TokenService.GenerateToken(user?.Result?.Login));
        }
    }
}
