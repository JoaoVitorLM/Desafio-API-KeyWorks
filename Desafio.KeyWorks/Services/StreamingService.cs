using Desafio.KeyWorks.Context;
using Desafio.KeyWorks.Models;
using Desafio.KeyWorks.Models.DTOs;

namespace Desafio.KeyWorks.Services
{
    public class StreamingService : BaseService
    {
        public StreamingService(AppDbContext context) : base(context)
        {
        }
        public Streaming Create(CreateStreamingDTO dto)
        {
            Streaming newStreaming = new(dto);

            context.Streamings.Add(newStreaming);
            context.SaveChanges();

            return newStreaming;
        }

        public Streaming GetById(int id)
        {
            Streaming streaming = context.Streamings.FirstOrDefault(s => s.Id == id);
            if (streaming == null)
            {
                throw new Exception("Streaming não encontrado");
            }
            return streaming;
        }

        public List<Streaming> Get()
        {
            return context.Streamings.ToList();
        }
    }
}
