namespace API.ApiServices.JikanService
{
    public class MangaContent
    {
        public Pagination Pagination { get; set; } = null!;
        public List<JikanManga> Data { get; set; } = null!;
    }
    
    public class JikanManga
    {
        public int Mal_id { get; set; }
        public JikanImages Images { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public Published Published { get; set; } = null!;
        public string Synopsis { get; set; } = string.Empty;
        public List<Author> Authors { get; set; } = [];
    }

    public class Published
    {
        public DateTime From { get; set; }
    }

    public class Author
    {
        public string Name { get; set; } = string.Empty;
    }
}