using Desafio.KeyWorks.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.KeyWorks.Models
{
    public class Streaming : BaseModel
    {
        protected Streaming() { }
        public Streaming(CreateStreamingDTO dto)
        {
            Name = dto.Name;
            Validate(this);
        }

        public string? Name { get; set; }

        private void Validate(Streaming data)
        {
            if (string.IsNullOrWhiteSpace(data.Name))
            {
                throw new ArgumentNullException(nameof(data.Name));
            }
        }

    }
}
