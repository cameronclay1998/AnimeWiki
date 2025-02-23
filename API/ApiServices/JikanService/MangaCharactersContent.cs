namespace API.ApiServices.JikanService
{
    public class MangaCharactersContent
    {
        public List<MangaCharacterData> Data { get; set; } = [];
    }

    public class MangaCharacterData
    {
        public JikanCharacter Character { get; set; } = null!;
    }
}