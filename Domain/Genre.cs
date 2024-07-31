namespace Domain
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<AnimeGenre> Animes { get; set; } = [];
    }
}