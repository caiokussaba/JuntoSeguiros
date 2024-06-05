using TesteJuntoSeguros.Domain.UserContext.Dtos;
using TesteJuntoSeguros.Domain.UserContext.Entities;

namespace TesteJuntoSeguros.Domain.UserContext.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto?> Create(User user);

        Task<UserDto?> Update(User user);

        Task<UserDto?> Delete(User user);

        Task<UserDto> GetById(User user);
    }
}
