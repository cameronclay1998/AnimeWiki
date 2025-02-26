using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SeedProcesses
{
    public class List
    {
        public class Query : IRequest<Result<List<SeedProcessDto>>>
        {
            public SeedProcessParams? Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<SeedProcessDto>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<SeedProcessDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.SeedProcesses.AsQueryable();

                var queryParams = request.Params;

                if (queryParams != null)
                {
                    if (!string.IsNullOrEmpty(queryParams.Name))
                    {
                        query = query.Where(x => x.Name == queryParams.Name);
                    }
                }

                var dtos = await query
                    .Select(x => new SeedProcessDto
                    {
                        Name = x.Name,
                        Id = x.Id.ToString(),
                        Counter = x.Counter
                    })
                    .ToListAsync();

                return Result<List<SeedProcessDto>>.Success(dtos);
            }
        }
    }
}