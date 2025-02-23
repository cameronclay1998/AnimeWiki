using Application.Characters;
using Domain;
using MediatR;

namespace API.ApiServices.JikanService
{
    public sealed class JikanService
    {
        private readonly HttpClient _client;
        private readonly IMediator _mediator;

        public JikanService(HttpClient client, IMediator mediator)
        {
            _client = client;
            _mediator = mediator;
        }

        public async Task SeedMangaCharacters()
        {
            var mangaContent = await _client.GetFromJsonAsync<MangaContent>("manga");

            // var 

            var mangaCharactersContent = await _client.GetFromJsonAsync<MangaCharactersContent>("manga/1/characters");

            if (mangaCharactersContent == null) return;

            var data = mangaCharactersContent.Data;

            foreach (var item in data)
            {
                var character = item.Character;
                var id = character.Mal_id;

                var charactersContent = await _client.GetFromJsonAsync<CharactersContent>($"characters/{id}");

                if (charactersContent == null) continue;
                
                character = charactersContent.Data;

                // Create character
                var dto = new CharacterDto
                {
                    Name = character.Name,
                    About = character.About,
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            Url = character.Images.Jpg.Image_url,
                            IsMain = true
                        }
                    }
                };

                await _mediator.Send(new Create.Command { Dto = dto });
            }
        }
    }
}