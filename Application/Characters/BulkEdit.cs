using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Characters
{
    public class BulkEdit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required ICollection<CharacterDto> Dtos { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;

            public Handler(IMapper mapper, DataContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                foreach (var dto in request.Dtos)
                {
                    if (string.IsNullOrEmpty(dto.Id))
                    {
                        return Result<Unit>.Failure("Character provided did not have an Id.");
                    }
                    
                    // Find existing character
                    var character = await _context.Characters.FindAsync(Guid.Parse(dto.Id));

                    if (character == null)
                    {
                        return Result<Unit>.Failure($"Character with Id: {dto.Id} was not found.");
                    }

                    // Map dto to character
                    _mapper.Map(dto, character);
                }

                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}