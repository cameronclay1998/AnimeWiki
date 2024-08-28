using Application.Core;
using MediatR;
using Persistence;

namespace Application.Animes
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(
                Command request, CancellationToken cancellationToken)
            {
                var id = request.Id;

                var anime = await _context.Animes.FindAsync(id);

                if (anime == null)
                {
                    return Result<Unit>.Failure($"Anime with Id: {id} was not found.");
                }

                _context.Animes.Remove(anime);

                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}