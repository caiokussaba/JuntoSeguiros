using Elastic.Apm.AspNetCore;

namespace TesteJuntoSeguros.Configurations
{
    public static class ElasticApm
    {
        public static void UseElasticApm(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseElasticApm(configuration);
        }
    }
}
