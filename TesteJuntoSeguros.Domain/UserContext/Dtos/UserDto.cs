using System.Text.Json.Serialization;

namespace TesteJuntoSeguros.Domain.UserContext.Dtos
{
    public class UserDto
    {
        public string? Id { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        [JsonIgnore]
        public string? HttpAction { get; set; }
    }
}
