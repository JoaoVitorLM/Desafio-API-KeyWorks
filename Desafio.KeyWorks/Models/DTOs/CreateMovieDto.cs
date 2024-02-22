namespace Desafio.KeyWorks.Models.DTOs
{
    public record CreateMovieDto(
        string Title,
        List<int> StreamingsIds,
        string Category,
        DateTime Release
        );

}
