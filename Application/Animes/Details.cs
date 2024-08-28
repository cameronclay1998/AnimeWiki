using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Animes
{
    public class Details
    {
        public class Query : IRequest<Result<AnimeDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<AnimeDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<AnimeDto>> Handle(
                Query request, CancellationToken cancellationToken)
            {
                var id = request.Id;

                var animeDto = await _context.Animes
                    .ProjectTo<AnimeDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(x => Guid.Parse(x.Id) == id);

                if (animeDto == null)
                {
                    return Result<AnimeDto>.Failure($"Anime with Id: {id} was not found.");
                }

                return Result<AnimeDto>.Success(animeDto);
            }
        }
    }
}