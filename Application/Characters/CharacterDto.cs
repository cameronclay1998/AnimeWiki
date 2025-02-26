using Domain;

namespace Application.Characters
{
    public class CharacterDto
    {
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
        public ICollection<Photo> Photos { get; set; } = [];
        public string? MangaId { get; set; }
        public int JikanId { get; set; }
    }
}