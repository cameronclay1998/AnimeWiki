using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Characters
{
    public class BulkCreate
    {
        public class Command : IRequest<Result<List<CharacterDto>>>
        {
            public required ICollection<CharacterDto> Dtos { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<List<CharacterDto>>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;

            public Handler(IMapper mapper, DataContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<CharacterDto>>> Handle(Command request, CancellationToken cancellationToken)
            {
                var characters = new List<Character>();

                foreach (var dto in request.Dtos)
                {
                    characters.Add(Utils.CreateCharacterFromDto(dto, _mapper));
                }

                _context.Characters.AddRange(characters);
                await _context.SaveChangesAsync();

                var dtos = new List<CharacterDto>();

                foreach (var character in characters)
                {
                    dtos.Add(_mapper.Map<CharacterDto>(character));
                }

                return Result<List<CharacterDto>>.Success(dtos);
            }
        }
    }
}