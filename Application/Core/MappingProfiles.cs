using Application.Animes;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Anime, AnimeDto>()
                .ForMember(d => d.Genres, o => o.MapFrom(s => s.Genres.Select(g => g.Genre.Name)));
        }
    }
}