using TesteJuntoSeguros.Application.UserContext.Interfaces.Factories;

namespace TesteJuntoSeguros.Application.UserContext.Factories.Creator
{
    public class HttpActionFactory : IHttpActionFactory
    {
        public IEnumerable<IHttpAction> _httpActions;

        public HttpActionFactory(IEnumerable<IHttpAction> httpActions)
            => _httpActions = httpActions;

        public IHttpAction GetHttpAction(string httpAction) 
            => _httpActions.FirstOrDefault(x => x.GetHttpAction() == httpAction);
    }
}
