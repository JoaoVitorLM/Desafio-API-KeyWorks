using Desafio.KeyWorks.Models.DTOs;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Desafio.KeyWorks.Models
{
    public class Rate : BaseModel
    {
        protected Rate() { }
        public Rate(AddMovieRateDto dto, Movie movie)
        {
            Comment = dto.Comment;
            Value = dto.Value;  
            UserName = dto.UserName;
            MovieId = movie.Id; 
            Validate(this);
        }
        public string Comment { get; set; }
        public int Value { get; set; }
        public string UserName { get; set; }
        public int? MovieId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Movie? Movie { get; set; }

        public void Validate(Rate rate)
        {
            if (string.IsNullOrWhiteSpace(rate.Comment)) 
            {
                throw new Exception("O comentário é obrigatório");
            }
            if (string.IsNullOrWhiteSpace(rate.UserName))
            {
                throw new Exception("O nome do usuário é obrigatório");
            }
            if (rate.Value < 1 || rate.Value > 5 )
            {
                throw new Exception("A avaliação tem que ser entre 1 e 5");
            }
        }

    }

}
