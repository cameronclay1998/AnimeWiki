namespace API.ApiServices.JikanService
{
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
}