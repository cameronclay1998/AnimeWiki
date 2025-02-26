using AutoMapper;
using Domain;
using Persistence;

namespace Application.Characters
{
    public static class Utils
    {
        public static Character CreateCharacterFromDto(CharacterDto dto, IMapper mapper)
        {
            var character = mapper.Map<Character>(dto);

            character.Id = Guid.NewGuid();

            // Handle photos
            foreach (var photo in dto.Photos)
            {
                photo.Id = Guid.NewGuid().ToString();
                character.Photos.Add(photo);
            }

            return character;
        }
    }
}