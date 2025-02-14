using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Mangas
{
    public class Edit
    {
        public class Command : IRequest<Result<MangaDto>>
        {
            public required Guid Id { get; set; }
            public required MangaDto Dto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<MangaDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<Result<MangaDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var manga = await _context.Mangas
                    .Include(m => m.Genres)
                    .Include(m => m.Photos)
                    .SingleOrDefaultAsync(m => m.Id == request.Id);

                if (manga == null)
                {
                    return Result<MangaDto>.Failure($"Manga with Id: {request.Id} was not found.");
                }

                var dto = request.Dto;
                _mapper.Map(dto, manga);
                
                HandlePhotoUpdates(dto, manga);

                // Handle genre changes
                var currentGenres = manga.Genres;
                var newGenres = dto.Genres;
                var genresToAdd = newGenres.Where(x => !currentGenres.Any(y => y.Genre.Name == x));
                var genresToRemove = currentGenres.Where(x => !newGenres.Any(y => y == x.Genre.Name));

                var genreEntities = await _context.Genres.ToListAsync();

                foreach (var genre in genresToAdd)
                {
                    var genreEntity = genreEntities.SingleOrDefault(x => x.Name == genre);

                    if (genreEntity == null)
                    {
                        return Result<MangaDto>.Failure($"Genre with Name: {genre} was not found.");
                    }

                    _context.MangaGenres.Add(new MangaGenre
                    {
                        Manga = manga,
                        Genre = genreEntity
                    });
                }

                foreach (var genre in genresToRemove)
                {
                    _context.MangaGenres.Remove(genre);
                }
                
                await _context.SaveChangesAsync();

                _mapper.Map(manga, dto);

                return Result<MangaDto>.Success(dto);
            }
            
            private static void HandlePhotoUpdates(MangaDto dto, Manga manga)
            {
                var existingIds = manga.Photos.Select(p => p.Id);
                var newIds = dto.Photos.Select(p => p.Id);

                var deleteList = manga.Photos.Where(p => !newIds.Contains(p.Id)).ToList();
                var createList = dto.Photos.Where(p => !existingIds.Contains(p.Id)).ToList();

                foreach (var photo in deleteList)
                {
                    manga.Photos.Remove(photo);
                }

                foreach (var photo in createList)
                {
                    photo.Id = Guid.NewGuid().ToString();
                    manga.Photos.Add(photo);
                }
            }
        }
    }
}