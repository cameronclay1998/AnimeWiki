using Domain;
using Domain.Enums;

namespace Persistence
{
    public class Seed
    {
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
                    Genres = new List<AnimeGenre>
                    {
                        AnimeGenre.Historical,
                        AnimeGenre.Adventure,
                        AnimeGenre.Action,
                        AnimeGenre.Drama,
                        AnimeGenre.Mystery
                    },
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
                    Genres = new List<AnimeGenre>
                    {
                        AnimeGenre.Action,
                        AnimeGenre.Adventure,
                        AnimeGenre.Drama,
                        AnimeGenre.Fantasy,
                        AnimeGenre.Mystery
                    },
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
                    Genres = new List<AnimeGenre>
                    {
                        AnimeGenre.Action,
                        AnimeGenre.Adventure,
                        AnimeGenre.Comedy,
                        AnimeGenre.Drama,
                        AnimeGenre.Fantasy
                    },
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
                    Genres = new List<AnimeGenre>
                    {
                        AnimeGenre.Action,
                        AnimeGenre.Adventure,
                        AnimeGenre.Drama,
                        AnimeGenre.Fantasy,
                        AnimeGenre.Mystery
                    },
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
                    Genres = new List<AnimeGenre>
                    {
                        AnimeGenre.Action,
                        AnimeGenre.Adventure,
                        AnimeGenre.Comedy,
                        AnimeGenre.Drama,
                        AnimeGenre.Fantasy
                    },
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
                    Genres = new List<AnimeGenre>
                    {
                        AnimeGenre.Action,
                        AnimeGenre.Adventure,
                        AnimeGenre.Comedy,
                        AnimeGenre.Drama,
                        AnimeGenre.Fantasy
                    },
                    AuthorFirstName = "Eiichiro",
                    AuthorLastName = "Oda"
                }
            };
            
            await context.Animes.AddRangeAsync(animes);
            await context.SaveChangesAsync();
        }
    }
}