using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Characters
{
    public class Create
    {
        public class Command : IRequest<Result<CharacterDto>>
        {
            public required CharacterDto Dto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<CharacterDto>>
        {
            private readonly IMapper _mapper;
            private readonly DataContext _context;

            public Handler(IMapper mapper, DataContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<CharacterDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var dto = request.Dto;
                var character = _mapper.Map<Character>(dto);

                character.Id = Guid.NewGuid();

                // Handle photos
                foreach (var photo in dto.Photos)
                {
                    photo.Id = Guid.NewGuid().ToString();
                    character.Photos.Add(photo);
                }

                _context.Characters.Add(character);
                await _context.SaveChangesAsync();

                _mapper.Map(character, dto);

                return Result<CharacterDto>.Success(dto);
            }
        }
    }
}