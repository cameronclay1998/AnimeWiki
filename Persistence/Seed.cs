using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedGenres(DataContext context)
        {
            if (context.Genres.Any()) return;

            var genres = new List<Genre>
            {
                new Genre { Id = Guid.NewGuid(), Name = "Action" },
                new Genre { Id = Guid.NewGuid(), Name = "Adventure" },
                new Genre { Id = Guid.NewGuid(), Name = "Comedy" },
                new Genre { Id = Guid.NewGuid(), Name = "Drama" },
                new Genre { Id = Guid.NewGuid(), Name = "Fantasy" },
                new Genre { Id = Guid.NewGuid(), Name = "Horror" },
                new Genre { Id = Guid.NewGuid(), Name = "Mystery" },
                new Genre { Id = Guid.NewGuid(), Name = "Romance" },
                new Genre { Id = Guid.NewGuid(), Name = "ScienceFiction" },
                new Genre { Id = Guid.NewGuid(), Name = "SliceOfLife" },
                new Genre { Id = Guid.NewGuid(), Name = "Sports" },
                new Genre { Id = Guid.NewGuid(), Name = "Supernatural" },
                new Genre { Id = Guid.NewGuid(), Name = "Thriller" },
                new Genre { Id = Guid.NewGuid(), Name = "Historical" },
                new Genre { Id = Guid.NewGuid(), Name = "Mecha" },
                new Genre { Id = Guid.NewGuid(), Name = "Music" },
                new Genre { Id = Guid.NewGuid(), Name = "Psychological" },
                new Genre { Id = Guid.NewGuid(), Name = "School" },
                new Genre { Id = Guid.NewGuid(), Name = "Isekai" },
                new Genre { Id = Guid.NewGuid(), Name = "Military" },
                new Genre { Id = Guid.NewGuid(), Name = "MartialArts" },
                new Genre { Id = Guid.NewGuid(), Name = "Shounen" },
                new Genre { Id = Guid.NewGuid(), Name = "Shoujo" },
                new Genre { Id = Guid.NewGuid(), Name = "Seinen" },
                new Genre { Id = Guid.NewGuid(), Name = "Josei" },
                new Genre { Id = Guid.NewGuid(), Name = "Harem" },
                new Genre { Id = Guid.NewGuid(), Name = "ReverseHarem" },
                new Genre { Id = Guid.NewGuid(), Name = "Ecchi" },
                new Genre { Id = Guid.NewGuid(), Name = "Yaoi" },
                new Genre { Id = Guid.NewGuid(), Name = "Yuri" }
            };

            await context.Genres.AddRangeAsync(genres);
            await context.SaveChangesAsync();
        }

        public static async Task SeedAnimes(DataContext context)
        {
            if (context.Animes.Any()) return;

            var animes = new List<Anime>
            {
                new Anime
                {
                    Title = "Golden Kamuy",
                    ReleaseDate = new DateTime(2018, 4, 9),
                    Description = "Sugimoto, a war veteran, searches for hidden gold in"
                        + " Hokkaido. Partnering with an Ainu girl, they face harsh climates"
                        + " and dangerous criminals in a thrilling survival adventure.",
                    // Genres = new List<AnimeGenre>
                    // {
                    //     AnimeGenre.Historical,
                    //     AnimeGenre.Adventure,
                    //     AnimeGenre.Action,
                    //     AnimeGenre.Drama,
                    //     AnimeGenre.Mystery
                    // },
                    AuthorFirstName = "Satoru",
                    AuthorLastName = "Noda"
                },
                new Anime
                {
                    Title = "Attack on Titan",
                    ReleaseDate = new DateTime(2013, 4, 7),
                    Description = "Humanity's remnants are forced to live behind massive walls"
                        + " to protect themselves from the man-eating Titans that roam the land"
                        + " outside. Eren Yeager, a young boy whose hometown is destroyed by"
                        + " Titans, vows to join the elite Survey Corps and eradicate the giant monsters.",
                    // Genres = new List<AnimeGenre>
                    // {
                    //     AnimeGenre.Action,
                    //     AnimeGenre.Adventure,
                    //     AnimeGenre.Drama,
                    //     AnimeGenre.Fantasy,
                    //     AnimeGenre.Mystery
                    // },
                    AuthorFirstName = "Hajime",
                    AuthorLastName = "Isayama"
                },
                new Anime
                {
                    Title = "My Hero Academia",
                    ReleaseDate = new DateTime(2016, 4, 3),
                    Description = "In a world where nearly everyone has superpowers known as Quirks,"
                        + " Izuku Midoriya is a Quirkless boy who dreams of becoming the greatest hero."
                        + " After a chance encounter with his idol All Might, Izuku's life changes forever.",
                    // Genres = new List<AnimeGenre>
                    // {
                    //     AnimeGenre.Action,
                    //     AnimeGenre.Adventure,
                    //     AnimeGenre.Comedy,
                    //     AnimeGenre.Drama,
                    //     AnimeGenre.Fantasy
                    // },
                    AuthorFirstName = "Kohei",
                    AuthorLastName = "Horikoshi"
                },
                new Anime
                {
                    Title = "Fullmetal Alchemist: Brotherhood",
                    ReleaseDate = new DateTime(2009, 4, 5),
                    Description = "Brothers Edward and Alphonse Elric use alchemy to try to revive"
                        + " their dead mother, but the attempt goes horribly wrong. To regain their"
                        + " bodies, they set off on a journey to find the Philosopher's Stone.",
                    // Genres = new List<AnimeGenre>
                    // {
                    //     AnimeGenre.Action,
                    //     AnimeGenre.Adventure,
                    //     AnimeGenre.Drama,
                    //     AnimeGenre.Fantasy,
                    //     AnimeGenre.Mystery
                    // },
                    AuthorFirstName = "Hiromu",
                    AuthorLastName = "Arakawa"
                },
                new Anime
                {
                    Title = "Naruto",
                    ReleaseDate = new DateTime(2002, 10, 3),
                    Description = "Naruto Uzumaki, a young ninja with a sealed demon fox spirit"
                        + " within him, seeks recognition from his peers and dreams of becoming"
                        + " the Hokage, the strongest ninja in the village.",
                    // Genres = new List<AnimeGenre>
                    // {
                    //     AnimeGenre.Action,
                    //     AnimeGenre.Adventure,
                    //     AnimeGenre.Comedy,
                    //     AnimeGenre.Drama,
                    //     AnimeGenre.Fantasy
                    // },
                    AuthorFirstName = "Masashi",
                    AuthorLastName = "Kishimoto"
                },
                new Anime
                {
                    Title = "One Piece",
                    ReleaseDate = new DateTime(1999, 10, 20),
                    Description = "Monkey D. Luffy, a young pirate with the ability to stretch his"
                        + " body like rubber after eating a Devil Fruit, sets out on a quest to find"
                        + " the legendary One Piece treasure and become the Pirate King.",
                    // Genres = new List<AnimeGenre>
                    // {
                    //     AnimeGenre.Action,
                    //     AnimeGenre.Adventure,
                    //     AnimeGenre.Comedy,
                    //     AnimeGenre.Drama,
                    //     AnimeGenre.Fantasy
                    // },
                    AuthorFirstName = "Eiichiro",
                    AuthorLastName = "Oda"
                }
            };

            await context.Animes.AddRangeAsync(animes);
            await context.SaveChangesAsync();
        }

        public static async Task SeedAnimeGenres(DataContext context)
        {
            if (context.AnimeGenres.Any()) return;
            if (!context.Animes.Any()) return;
            if (!context.Genres.Any()) return;

            var action = await FindGenre(context, "Action");
            var adventure = await FindGenre(context, "Adventure");
            var comedy = await FindGenre(context, "Comedy");
            var drama = await FindGenre(context, "Drama");
            var fantasy = await FindGenre(context, "Fantasy");
            var mystery = await FindGenre(context, "Mystery");
            var historical = await FindGenre(context, "Historical");

            var animeGenres = new List<AnimeGenre>();

            foreach (var anime in context.Animes)
            {
                animeGenres.Add(new AnimeGenre { Anime = anime, Genre = action });
                animeGenres.Add(new AnimeGenre { Anime = anime, Genre = adventure });
                animeGenres.Add(new AnimeGenre { Anime = anime, Genre = drama });

                switch (anime.Title)
                {
                    case "Golden Kamuy":
                        {
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = historical });
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = mystery });
                            break;
                        }
                    case "Attack on Titan":
                        {
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = mystery });
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = fantasy });
                            break;
                        }
                    case "My Hero Academia":
                        {
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = comedy });
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = fantasy });
                            break;
                        }
                    case "Fullmetal Alchemist: Brotherhood":
                        {
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = mystery });
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = fantasy });
                            break;
                        }
                    case "Naruto":
                        {
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = comedy });
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = fantasy });
                            break;
                        }
                    case "One Piece":
                        {
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = comedy });
                            animeGenres.Add(new AnimeGenre { Anime = anime, Genre = fantasy });
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            await context.AnimeGenres.AddRangeAsync(animeGenres);
            await context.SaveChangesAsync();
        }

        private static async Task<Anime> FindAnime(DataContext context, string title)
        {
            return await context.Animes.SingleOrDefaultAsync(a => a.Title == title)
                ?? throw new Exception($"Anime {title} was not found.");
        }

        private static async Task<Genre> FindGenre(DataContext context, string name)
        {
            return await context.Genres.SingleOrDefaultAsync(g => g.Name == name)
                ?? throw new Exception($"Genre {name} was not found.");
        }
    }
}