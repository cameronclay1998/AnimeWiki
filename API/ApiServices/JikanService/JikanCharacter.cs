namespace API.ApiServices.JikanService
{
    public class JikanCharacter
    {
        public int Mal_id { get; set; }
        public JikanImages Images { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
    }
}