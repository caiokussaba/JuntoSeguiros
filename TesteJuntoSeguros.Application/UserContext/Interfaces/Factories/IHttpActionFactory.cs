namespace TesteJuntoSeguros.Application.UserContext.Interfaces.Factories
{
    public interface IHttpActionFactory
    {
        IHttpAction GetHttpAction(string? type);
    }
}
