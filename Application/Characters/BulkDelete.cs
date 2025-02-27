using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Characters
{
    public class BulkDelete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required List<string> Ids { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var ids = request.Ids;

                foreach (var id in ids)
                {
                    var character = await _context.Characters.FindAsync(Guid.Parse(id));

                    if (character == null) continue;

                    _context.Characters.Remove(character);
                }

                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}