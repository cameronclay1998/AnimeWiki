using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Mangas
{
    public class List
    {
        public class Query : IRequest<Result<List<MangaDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<MangaDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<Result<List<MangaDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dtos = await _context.Mangas
                    .Take(500)
                    .ProjectTo<MangaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<MangaDto>>.Success(dtos);
            }
        }
    }
}