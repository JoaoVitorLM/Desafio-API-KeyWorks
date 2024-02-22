namespace Desafio.KeyWorks.Models.DTOs
{
    public class MovieByYearDto
    {
        public MovieByYearDto(List<Movie> movies)
        {
            Total = movies.Count;
            Movies = movies;
        }
        public int Total { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
