using Application.Core;
using MediatR;
using Persistence;

namespace Application.SeedProcesses
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
            public required SeedProcessDto Dto { get; set; }
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
                var id = request.Id;
                var dto = request.Dto;
                
                var seedProcess = await _context.SeedProcesses.FindAsync(id);
                
                if (seedProcess == null)
                {
                    return Result<Unit>.Failure($"SeedProcess with Id: {id} was not found.");
                }
                
                seedProcess.Counter = dto.Counter;
                seedProcess.Name = dto.Name;

                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}