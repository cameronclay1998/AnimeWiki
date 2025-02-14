namespace Domain
{
    public class MangaGenre
    {
        public Guid MangaId { get; set; }
        public Guid GenreId { get; set; }
        public Manga Manga { get; set; } = null!;
        public Genre Genre { get; set; } = null!;
    }
}