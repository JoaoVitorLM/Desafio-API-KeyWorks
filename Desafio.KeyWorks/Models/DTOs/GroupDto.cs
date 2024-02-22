namespace Desafio.KeyWorks.Models.DTOs
{
    public class GroupDto
    {
        public GroupDto(string category)
        {
            Category = category;
        }
        public string Category { get; set; }
        public List<Movie> Movies { get; set; } = new();
    }
}
