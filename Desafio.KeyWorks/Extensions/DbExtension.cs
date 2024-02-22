using Desafio.KeyWorks.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.KeyWorks.Extensions
{
    public static class DbExtension
    {
     public static void ConfigureDb(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Acervo Filmes"));
        }
    }
}
