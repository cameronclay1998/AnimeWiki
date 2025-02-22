namespace Domain
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
        public ICollection<Photo> Photos { get; set; } = [];
        public Guid MangaId { get; set; }
        public Manga? Manga { get; set; }
    }
}