namespace Application.Animes
{
    public class AnimeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AuthorFirstName { get; set; } = string.Empty;
        public string AuthorLastName { get; set; } = string.Empty;
        public ICollection<string> Genres { get; set; } = [];
    }
}