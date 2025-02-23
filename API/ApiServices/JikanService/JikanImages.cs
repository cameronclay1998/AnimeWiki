namespace API.ApiServices.JikanService
{
    public class JikanImages
    {
        public Jpg Jpg { get; set; } = null!;
    }

    public class Jpg
    {
        public string Image_url { get; set; } = string.Empty;
    }
}