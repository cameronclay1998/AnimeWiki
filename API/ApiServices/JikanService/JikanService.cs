namespace API.ApiServices.JikanService
{
    public sealed class JikanService
    {
        private readonly HttpClient _client;

        public JikanService(HttpClient client)
        {
            _client = client;
        }

        public async Task SeedMangaCharacters()
        {
            var response = await _client.GetAsync("manga/1/characters");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }
}