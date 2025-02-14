using Application.Animes;
using Application.Genres;
using Application.Mangas;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Anime, AnimeDto>()
                .ForMember(d => d.Genres, o => o.MapFrom(s => s.Genres.Select(g => g.Genre.Name)))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToString()));
                
            CreateMap<AnimeDto, Anime>()
                .ForMember(d => d.Genres, o => o.Ignore())
                .ForMember(d => d.Id, o => o.MapFrom(s => string.IsNullOrEmpty(s.Id) ? Guid.Empty : Guid.Parse(s.Id)))
                .ForMember(d => d.Photos, o => o.Ignore());

            CreateMap<Genre, GenreDto>();

            CreateMap<Manga, MangaDto>()
                .ForMember(d => d.Genres, o => o.MapFrom(s => s.Genres.Select(g => g.Genre.Name)))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToString()));
            
            CreateMap<MangaDto, Manga>()
                .ForMember(d => d.Genres, o => o.Ignore())
                .ForMember(d => d.Id, o => o.MapFrom(s => string.IsNullOrEmpty(s.Id) ? Guid.Empty : Guid.Parse(s.Id)))
                .ForMember(d => d.Photos, o => o.Ignore());
        }
    }
}