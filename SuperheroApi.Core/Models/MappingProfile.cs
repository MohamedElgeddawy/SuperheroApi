using AutoMapper;
using SuperheroApi.Core.Models.Superhero;

namespace SuperheroApi.Core.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SuperheroApiResponse, Superhero.Superhero>()
                .ForMember(dest => dest.Appearance, opt => opt.MapFrom(src => src.Appearance ?? new AppearanceApiResponse()))
                .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography ?? new BiographyApiResponse()))
                .ForMember(dest => dest.Powerstats, opt => opt.MapFrom(src => src.Powerstats ?? new PowerstatsApiResponse()))
                .ForMember(dest => dest.Work, opt => opt.MapFrom(src => src.Work ?? new WorkApiResponse()))
                .ForMember(dest => dest.Connections, opt => opt.MapFrom(src => src.Connections ?? new ConnectionsApiResponse()))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image ?? new ImageApiResponse()));

            CreateMap<PowerstatsApiResponse, PowerStats>();

            CreateMap<BiographyApiResponse, Biography>()
                .ForMember(dest => dest.FirstAppearance, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.FirstAppearance) ? "Unknown" : src.FirstAppearance));

            CreateMap<AppearanceApiResponse, Appearance>()
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height != null && src.Height.Count > 0 ? src.Height[0] : "Unknown"))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight != null && src.Weight.Count > 0 ? src.Weight[0] : "Unknown"));

            CreateMap<WorkApiResponse, Work>()
                .ForMember(dest => dest.Base, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Base) ? "Unknown" : src.Base));

            CreateMap<ConnectionsApiResponse, Connections>()
                .ForMember(dest => dest.GroupAffiliation, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.GroupAffiliation) ? "N/A" : src.GroupAffiliation))
                .ForMember(dest => dest.Relatives, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Relatives) ? "N/A" : src.Relatives));

            CreateMap<ImageApiResponse, Image>();
        }
    }
}
