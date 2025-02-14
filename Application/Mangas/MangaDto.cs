using Domain;

namespace Application.Mangas
{
    public class MangaDto
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime Published { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public ICollection<string> Genres { get; set; } = [];
        public ICollection<Photo> Photos { get; set; } = [];
    }
}