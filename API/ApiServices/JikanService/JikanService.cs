using Application.Characters;
using Application.Mangas;
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

        // public async Task SeedMangaCharacters()
        // {
        //     bool has_next_page = true;
        //     int page = 1;

        //     while (has_next_page)
        //     {
        //         var mangaContent = await CreateRequest<MangaContent>($"manga?page={page}");

        //         foreach (var manga in mangaContent.Data)
        //         {
        //             await _mediator.Send(new BulkCreate.Command
        //             {
        //                 Dtos = await CreateNewCharactersFromManga(manga)
        //             });
        //         }

        //         has_next_page = mangaContent.Pagination.Has_next_page;
        //         page++;
        //     }
        // }

        public async Task SeedCharacters()
        {
            bool has_next_page = true;
            int page = 1;

            var charactersListResponse = await _mediator.Send(new Application.Characters.List.Query());

            if (!charactersListResponse.IsSuccess || charactersListResponse.Value == null)
            {
                throw new Exception($"Characters list response resulted in error. Error: {charactersListResponse.Error}");
            }

            var jikanIds = charactersListResponse.Value.Select(x => x.JikanId);

            while (has_next_page)
            {
                var charactersContent = await CreateRequest<CharactersContent>($"characters?page={page}");
                
                var newCharacters = new List<CharacterDto>();

                foreach (var jikanCharacter in charactersContent.Data)
                {
                    if (!jikanIds.Contains(jikanCharacter.Mal_id))
                    {
                        newCharacters.Add(CreateCharacter(jikanCharacter));
                    }
                }
                
                await _mediator.Send(new BulkCreate.Command { Dtos = newCharacters });

                has_next_page = charactersContent.Pagination.Has_next_page;
                page++;
            }
        }

        private async Task<List<CharacterDto>> CreateNewCharactersFromManga(JikanManga jikanManga)
        {
            var mangaCharactersContent = await CreateRequest<MangaCharactersContent>($"manga/{jikanManga.Mal_id}/characters");

            var newCharacters = new List<CharacterDto>();

            foreach (var item in mangaCharactersContent.Data)
            {
                var jikanCharacter = item.Character;
                var id = jikanCharacter.Mal_id;

                var charactersContent = await CreateRequest<CharactersByIdContent>($"characters/{id}");

                jikanCharacter = charactersContent.Data;

                // Find related manga by title
                var mangasResponse = await _mediator.Send(new Application.Mangas.List.Query { Params = new MangaParams { Title = jikanManga.Title } });

                if (!mangasResponse.IsSuccess || mangasResponse.Value == null) continue;

                var manga = mangasResponse.Value.FirstOrDefault();

                if (manga == null)
                {
                    manga = await CreateManga(jikanManga);
                }

                // Check if character exists by manga id and character name
                var characterResponse = await _mediator.Send(
                    new Application.Characters.List.Query
                    {
                        Params = new CharacterParams
                        {
                            MangaId = manga.Id,
                            Name = jikanCharacter.Name
                        }
                    });

                if (!characterResponse.IsSuccess || characterResponse.Value == null) continue;

                var character = characterResponse.Value.FirstOrDefault();

                if (character == null)
                {
                    newCharacters.Add(CreateCharacter(jikanCharacter, manga.Id));
                }
            }

            return newCharacters;
        }

        /// <summary>
        /// Create new manga based on jikan manga.
        /// </summary>
        private async Task<MangaDto> CreateManga(JikanManga jikanManga)
        {
            var mangaCreateResponse = await _mediator.Send(new Application.Mangas.Create.Command
            {
                Dto = new MangaDto
                {
                    Title = jikanManga.Title,
                    Published = jikanManga.Published.From,
                    Description = jikanManga.Synopsis,
                    Author = jikanManga.Authors.FirstOrDefault()?.Name ?? "Unknown",
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            IsMain = true,
                            Url = jikanManga.Images.Jpg.Image_url
                        }
                    }
                }
            });

            if (!mangaCreateResponse.IsSuccess || mangaCreateResponse.Value == null)
            {
                throw new Exception($"Error occurred while attempting to create a new manga. Error: {mangaCreateResponse.Error}");
            }

            return mangaCreateResponse.Value;
        }

        private CharacterDto CreateCharacter(JikanCharacter character, string? mangaId = null)
        {
            return new CharacterDto
            {
                Name = character.Name,
                About = character.About ?? "Unknown",
                Photos = new List<Photo>
                    {
                        new Photo
                        {
                            Url = character.Images.Jpg.Image_url,
                            IsMain = true
                        }
                    },
                MangaId = mangaId,
                JikanId = character.Mal_id
            };
        }

        private async Task<T> CreateRequest<T>(string url)
        {
            // Jikan API is rate limited to 60 requests per minute
            Thread.Sleep(1000);

            return await _client.GetFromJsonAsync<T>(url)
                ?? throw new Exception($"{typeof(T).Name} was null.");
        }
    }
}