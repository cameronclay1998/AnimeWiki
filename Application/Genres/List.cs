using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genres
{
    public class List
    {
        public class Query : IRequest<Result<List<GenreDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<GenreDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<GenreDto>>> Handle(
                Query request, CancellationToken cancellationToken)
            {
                var genres = await _context.Genres
                    .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<GenreDto>>.Success(genres);
            }
        }
    }
}