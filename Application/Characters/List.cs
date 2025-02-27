using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Characters
{
    public class List
    {
        public class Query : IRequest<Result<List<CharacterDto>>>
        {
            public CharacterParams? Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<CharacterDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<CharacterDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dtos = _context.Characters
                    .ProjectTo<CharacterDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                var queryParams = request.Params;

                if (queryParams != null)
                {
                    var mangaId = queryParams.MangaId;
                    var name = queryParams.Name;
                    var jikanId = queryParams.JikanId;

                    if (!string.IsNullOrEmpty(mangaId))
                    {
                        dtos = dtos.Where(x => x.MangaId == mangaId);
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        dtos = dtos.Where(x => x.Name == name);
                    }

                    if (jikanId.HasValue)
                    {
                        dtos = dtos.Where(x => x.JikanId == jikanId.Value);
                    }
                }
                else
                {
                    // dtos = dtos.Take(500);
                }

                return Result<List<CharacterDto>>.Success(await dtos.ToListAsync());
            }
        }
    }
}