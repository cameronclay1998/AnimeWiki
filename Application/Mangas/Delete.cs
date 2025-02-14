using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Mangas
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var manga = await _context.Mangas
                    .Include(m => m.Genres)
                    .Include(m => m.Photos)
                    .SingleOrDefaultAsync(m => m.Id == request.Id);

                if (manga == null)
                {
                    return Result<Unit>.Failure($"Manga with Id: {request.Id} was not found.");
                }

                _context.Mangas.Remove(manga);
                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}