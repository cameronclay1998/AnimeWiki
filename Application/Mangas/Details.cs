using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Mangas
{
    public class Details
    {
        public class Query : IRequest<Result<MangaDto>>
        {
            public required Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<MangaDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<Result<MangaDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dto = await _context.Mangas
                    .ProjectTo<MangaDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(m => m.Id == request.Id.ToString());

                if (dto == null)
                {
                    return Result<MangaDto>.Failure($"Manga with Id: {request.Id} was not found.");
                }

                return Result<MangaDto>.Success(dto);
            }
        }
    }
}