using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Animes
{
    public class List
    {
        public class Query : IRequest<Result<List<Anime>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Anime>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Anime>>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var animes = await _context.Animes.ToListAsync();
                return Result<List<Anime>>.Success(animes);
            }
        }
    }
}