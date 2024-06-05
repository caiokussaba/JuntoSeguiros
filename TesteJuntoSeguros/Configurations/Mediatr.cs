using TesteJuntoSeguros.Application.AuthenticationContext.Handler;
using TesteJuntoSeguros.Application.UserContext.Handler;

namespace TesteJuntoSeguros.Configurations
{
    public static class MediatrConfiguration
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuthenticationHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserHandler).Assembly));
            return services;
        }
    }
}
