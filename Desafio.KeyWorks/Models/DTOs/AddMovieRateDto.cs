namespace Desafio.KeyWorks.Models.DTOs
{
    public record AddMovieRateDto(
        string Comment, 
        int Value,
        string UserName,
        int MovieId
        );
}
