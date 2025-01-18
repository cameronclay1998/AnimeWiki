using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Animes
{
    public class List
    {
        public class Query : IRequest<Result<List<AnimeDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<AnimeDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<AnimeDto>>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var animes = await _context.Animes
                    .ProjectTo<AnimeDto>(_mapper.ConfigurationProvider)
                    .OrderBy(a => a.Title)
                    .ToListAsync();
                    
                return Result<List<AnimeDto>>.Success(animes);
            }
        }
    }
}