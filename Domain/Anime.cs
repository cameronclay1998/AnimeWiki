namespace Domain
{
    public class Anime
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AuthorFirstName { get; set; } = string.Empty;
        public string AuthorLastName { get; set; } = string.Empty;
        public ICollection<AnimeGenre> Genres { get; set; } = [];
        public ICollection<Photo> Photos { get; set; } = [];
    }
}