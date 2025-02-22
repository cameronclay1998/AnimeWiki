namespace Domain
{
    public class Manga
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Published { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public ICollection<MangaGenre> Genres { get; set; } = [];
        public ICollection<Photo> Photos { get; set; } = [];
        public ICollection<Character> Characters { get; set; } = [];
    }
}