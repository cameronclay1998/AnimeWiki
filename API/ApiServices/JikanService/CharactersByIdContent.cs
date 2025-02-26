namespace API.ApiServices.JikanService
{
    public class CharactersByIdContent
    {
        public JikanCharacter Data { get; set; } = null!;
        public Pagination Pagination { get; set; } = null!;
    }
}