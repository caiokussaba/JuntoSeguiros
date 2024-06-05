using TesteJuntoSeguros.Domain.CommomContext;

namespace TesteJuntoSeguros.Domain.UserContext.Entities
{
    public class User : BaseEntity
    {
        public string? Login { get; set; }

        public string? Password { get; set; }

        public DateTime? LastUpdate { get; set; } = DateTime.Now;

        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
