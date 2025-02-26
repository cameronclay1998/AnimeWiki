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
            public MangaParams? Params { get; set; }
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
                var dtos = _context.Mangas
                    .ProjectTo<MangaDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                var queryParams = request.Params;

                if (queryParams != null && !string.IsNullOrEmpty(queryParams.Title))
                {
                    dtos = dtos.Where(x => x.Title == queryParams.Title);
                }
                else
                {
                    dtos = dtos.Take(500);
                }

                return Result<List<MangaDto>>.Success(await dtos.ToListAsync());
            }
        }
    }
}