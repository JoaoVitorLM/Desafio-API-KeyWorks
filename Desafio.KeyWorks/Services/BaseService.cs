using Desafio.KeyWorks.Context;

namespace Desafio.KeyWorks.Services
{
    public class BaseService
    {
        public readonly AppDbContext context;
        public BaseService(AppDbContext context)
        {
            this.context = context; 
        }
    }
}
