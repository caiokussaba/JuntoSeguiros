using TesteJuntoSeguros.Domain.AuthenticationContext.Request;
using TesteJuntoSeguros.Domain.UserContext.Entities;

namespace TesteJuntoSeguros.Domain.AuthenticationContext.Interface
{
    public interface IAuthenticationRepository
    {
        Task<User?> SignInByLogin(AuthenticationRequest authenticationRequest);
    }
}
