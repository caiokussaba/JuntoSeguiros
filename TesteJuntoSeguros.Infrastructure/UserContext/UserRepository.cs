using TesteJuntoSeguros.Domain.UserContext.Dtos;
using TesteJuntoSeguros.Domain.UserContext.Entities;
using TesteJuntoSeguros.Domain.UserContext.Interfaces;
using TesteJuntoSeguros.Infrastructure.CommomContext;
using Dapper;

namespace TesteJuntoSeguros.Infrastructure.UserContext
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) => _context = context;

        public async Task<UserDto?> Create(User user)
        {
            var sql = @"INSERT INTO user (Id, login, password, createdate) 
                        VALUES (@Id, @Login, @Password, @CreateDate)";

            using (var connection = _context.CreateConnection())
            {

                try
                {
                    var id = await connection.ExecuteScalarAsync<string>(sql, new
                    {
                        user.Id,
                        user.Login,
                        user.Password,
                        user.CreateDate
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }

                if (user.Id is null)
                    return null;

                return new UserDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password
                };
            }
        }

        public async Task<UserDto?> Delete(User user)
        {
            var sql = @"DELETE FROM user WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var affectedRows = await connection.ExecuteAsync(sql, new { Id = user.Id });

                    if (affectedRows == 0)
                        return null;

                    return new UserDto
                    {
                        Id = user.Id,
                        Login = user.Login
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public async Task<UserDto?> Update(User user)
        {
            var sql = @"UPDATE user SET login = @Login, password = @Password, lastupdate = @LastUpdate WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var affectedRows = await connection.ExecuteAsync(sql, new
                    {
                        user.Id,
                        user.Login,
                        user.Password,
                        user.LastUpdate
                    });

                    if (affectedRows == 0)
                        return null;

                    return new UserDto
                    {
                        Id = user.Id,
                        Login = user.Login
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public async Task<UserDto> GetById(User user)
        {
            var sql = @"SELECT Id, login, createdate FROM user WHERE Id = @id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<User>(sql, new { user.Id });

                var response = new UserDto
                {
                    Id = result?.Id,
                    Login = result?.Login
                };

                return response;
            }
        }
    }
}
