using Desafio.KeyWorks.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.Marshalling;

namespace Desafio.KeyWorks.Models
{
    public class Movie : BaseModel
    {
        protected Movie() { }
        public Movie(CreateMovieDto dto, List<Streaming> streamings)
        {
            Title = dto.Title;
            Category = dto.Category;
            Release = dto.Release;
            Streamings = streamings;
            Validate(this);
        }
        public Movie(Movie movie)
        {
            Title = movie.Title;
            Category = movie.Category;
            Release = movie.Release;
            Streamings = movie.Streamings;
            Rates = movie.Rates;
            AverageRate = CalculateAverage(movie);
        }
        public string Title { get; set; }
        public string Category { get; set; }

        public DateTime Release { get; set; }

        public List<Streaming> Streamings { get; set; } = new();

        public List<Rate> Rates { get; set; } = new();

        public double AverageRate { get; set; }
        public void Validate(Movie movie)
        {
            if (string.IsNullOrWhiteSpace(movie.Title))
            {
                throw new ArgumentException("Title é obrigatório");
            }
            if (string.IsNullOrWhiteSpace(movie.Category))
            {
                throw new ArgumentException("Category é obrigatório");
            }
            if (DateTime.MinValue == movie.Release)
            {
                throw new ArgumentException("Release é obrigatório");
            }
            if (movie.Streamings.Count() == 0)
            {
                throw new ArgumentException("Streamings é obrigatório");
            }
        }

        public double CalculateAverage(Movie movie)
        {
            var rates = movie.Rates;
            if (rates.Count == 0) return 0;

            var sumRate = rates.Select(r => r.Value).Sum();
            var average = sumRate / rates.Count;

            return average;
        }
    }
}
