using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Mangas
{
    public class Create
    {
        public class Command : IRequest<Result<MangaDto>>
        {
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
                var dto = request.Dto;
                var manga = _mapper.Map<Manga>(dto);

                manga.Id = Guid.NewGuid();

                foreach (var photo in manga.Photos)
                {
                    photo.Id = Guid.NewGuid().ToString();
                }

                _context.Mangas.Add(manga);

                var availableGenres = await _context.Genres.ToListAsync();

                // Handle genres
                var newGenres = dto.Genres;
                foreach (var genre in newGenres)
                {
                    var genreEntity = availableGenres.SingleOrDefault(x => x.Name == genre);

                    if (genreEntity == null)
                    {
                        return Result<MangaDto>.Failure($"Genre with Name: {genre} was not found.");
                    }

                    _context.MangaGenres.Add(new MangaGenre
                    {
                        Genre = genreEntity,
                        Manga = manga
                    });
                }

                await _context.SaveChangesAsync();

                _mapper.Map(manga, dto);

                return Result<MangaDto>.Success(dto);
            }
        }
    }
}