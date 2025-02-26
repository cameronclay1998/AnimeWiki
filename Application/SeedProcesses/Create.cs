using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.SeedProcesses
{
    public class Create
    {
        public class Command : IRequest<Result<SeedProcessDto>>
        {
            public required SeedProcessDto Dto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<SeedProcessDto>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<SeedProcessDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var dto = request.Dto;
                
                if (_context.SeedProcesses.Any(x => x.Name == dto.Name))
                {
                    return Result<SeedProcessDto>.Failure($"SeedProcess with Name: {dto.Name} already exists.");
                }

                var seedProcess = new SeedProcess
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Counter = 1
                };

                _context.SeedProcesses.Add(seedProcess);

                await _context.SaveChangesAsync();
                
                dto.Counter = seedProcess.Counter;
                dto.Id = seedProcess.Id.ToString();

                return Result<SeedProcessDto>.Success(dto);
            }
        }
    }
}