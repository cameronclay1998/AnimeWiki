using Domain;

namespace Application.Animes
{
    public class AnimeDto
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AuthorFirstName { get; set; } = string.Empty;
        public string AuthorLastName { get; set; } = string.Empty;
        public ICollection<string> Genres { get; set; } = [];
        public ICollection<Photo> Photos { get; set; } = [];
    }
}