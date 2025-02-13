using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Animes
{
    public class Edit
    {
        public class Command : IRequest<Result<AnimeDto>>
        {
            public Guid Id { get; set; }
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
                var id = request.Id;
                
                var anime = await _context.Animes
                    .Include(x => x.Genres)
                    .Include(x => x.Photos)
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (anime == null)
                {
                    return Result<AnimeDto>.Failure($"Anime with Id: {id} was not found.");
                }

                _mapper.Map(animeDto, anime);

                HandlePhotoUpdates(animeDto, anime);

                // Handle genre changes
                var currentGenres = anime.Genres;
                var newGenres = animeDto.Genres;
                var genresToAdd = newGenres.Where(x => !currentGenres.Any(y => y.Genre.Name == x));
                var genresToRemove = currentGenres.Where(x => !newGenres.Any(y => y == x.Genre.Name));

                var genreEntities = await _context.Genres.ToListAsync();

                foreach (var genre in genresToAdd)
                {
                    var genreEntity = genreEntities.SingleOrDefault(x => x.Name == genre);

                    if (genreEntity == null)
                    {
                        return Result<AnimeDto>.Failure($"Genre with Name: {genre} was not found.");
                    }

                    _context.AnimeGenres.Add(new AnimeGenre
                    {
                        Anime = anime,
                        Genre = genreEntity
                    });
                }

                foreach (var genre in genresToRemove)
                {
                    _context.AnimeGenres.Remove(genre);
                }

                await _context.SaveChangesAsync();

                _mapper.Map(anime, animeDto);

                return Result<AnimeDto>.Success(animeDto);
            }

            private static void HandlePhotoUpdates(AnimeDto dto, Anime anime)
            {
                var existingIds = anime.Photos.Select(p => p.Id);
                var newIds = dto.Photos.Select(p => p.Id);

                var deleteList = anime.Photos.Where(p => !newIds.Contains(p.Id)).ToList();
                var createList = dto.Photos.Where(p => !existingIds.Contains(p.Id)).ToList();

                foreach (var photo in deleteList)
                {
                    anime.Photos.Remove(photo);
                }

                foreach (var photo in createList)
                {
                    photo.Id = Guid.NewGuid().ToString();
                    anime.Photos.Add(photo);
                }
            }
        }
    }
}