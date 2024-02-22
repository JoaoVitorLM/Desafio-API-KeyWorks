using Desafio.KeyWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.KeyWorks.Context
{
    public class AppDbContext : DbContext  
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
          
        }
        public DbSet<Streaming> Streamings  { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
