using TesteJuntoSeguros.Application.UserContext.Util;
using TesteJuntoSeguros.Domain.AuthenticationContext.Interface;
using TesteJuntoSeguros.Domain.AuthenticationContext.Request;
using TesteJuntoSeguros.Domain.UserContext.Entities;
using TesteJuntoSeguros.Infrastructure.CommomContext;
using Dapper;

namespace TesteJuntoSeguros.Infrastructure.AuthenticationContext.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DataContext _context;
        public AuthenticationRepository(DataContext context) => _context = context;

        public async Task<User?> SignInByLogin(AuthenticationRequest authenticationRequest)
        {
            var sql = @"SELECT login, password FROM user WHERE login = @Login";

            using (var connection = _context.CreateConnection())
            {
                var response =  await connection.QueryFirstOrDefaultAsync<User>(sql, new { authenticationRequest.Login });
                var abc = Utils.ValidatePassword(authenticationRequest.Password, response.Password);

                if (Utils.ValidatePassword(authenticationRequest.Password, response.Password))
                    return response;

                return null;
            }
        }
    }
}
