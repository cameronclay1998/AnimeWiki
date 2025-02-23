namespace API.ApiServices.JikanService
{
    public class MangaContent
    {
        public Pagination Pagination { get; set; } = null!;
        public List<JikanManga> Data { get; set; } = null!;
    }

    public class Pagination
    {
        public int Last_visible_page { get; set; }
        public bool Has_next_page { get; set; }
        public int Current_page { get; set; }
        public Items Items { get; set; } = null!;
    }

    public class Items
    {
        public int Count { get; set; }
        public int Total { get; set; }
        public int Per_page { get; set; }
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