namespace Desafio.KeyWorks.Models.DTOs
{
    public record UpdateMovieDto(
        string Title, 
        string Category,
        List<int> StreamingsId,
        DateTime Release,
        int Id
        );
}
