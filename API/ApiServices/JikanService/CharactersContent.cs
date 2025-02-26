namespace API.ApiServices.JikanService
{
    public class CharactersContent
    {
        public ICollection<JikanCharacter> Data { get; set; } = null!;
        public Pagination Pagination { get; set; } = null!;
    }
}