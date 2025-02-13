using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Animes
{
    public class Create
    {
        public class Command : IRequest<Result<AnimeDto>>
        {
            public AnimeDto AnimeDto { get; set; } = null!;
        }

        public class Handler : IRequestHandler<Command, Result<AnimeDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<AnimeDto>> Handle(
                Command request, CancellationToken cancellationToken)
            {
                var animeDto = request.AnimeDto;

                var anime = _mapper.Map<Anime>(animeDto);

                anime.Id = Guid.NewGuid();

                foreach (var photo in anime.Photos)
                {
                    photo.Id = Guid.NewGuid().ToString();
                }

                _context.Animes.Add(anime);

                var availableGenres = await _context.Genres.ToListAsync();

                // Handle genres
                var newGenres = animeDto.Genres;
                foreach (var genre in newGenres)
                {
                    var genreEntity = availableGenres.SingleOrDefault(x => x.Name == genre);

                    if (genreEntity == null)
                    {
                        return Result<AnimeDto>.Failure($"Genre with Name: {genre} was not found.");
                    }

                    _context.AnimeGenres.Add(new AnimeGenre
                    {
                        Genre = genreEntity,
                        Anime = anime
                    });
                }

                await _context.SaveChangesAsync();

                _mapper.Map(anime, animeDto);

                return Result<AnimeDto>.Success(animeDto);
            }
        }
    }
}