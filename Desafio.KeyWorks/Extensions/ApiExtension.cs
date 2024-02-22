using Desafio.KeyWorks.Services;

namespace Desafio.KeyWorks.Extensions
{
    public static class ApiExtension
    {
        public static void ConfigureServices(this WebApplicationBuilder builder) 
        {
            builder.Services
                .AddScoped<StreamingService>()
                .AddScoped<MovieService>();
        }
    }
}
