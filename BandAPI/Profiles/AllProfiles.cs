using AutoMapper;
using BandAPI.Entities;
using BandAPI.Models;

namespace BandAPI.Profiles
{
    public class AllProfiles : Profile
    {
        public AllProfiles()
        {
            CreateMap<Band, BandDto>()
                 .ForMember(m => m.Genres, c => c.MapFrom(s => s.Description.Genres));
            CreateMap<Album, AlbumDto>();
            CreateMap<Description, DescriptionDto>();
            CreateMap<Musician, MusicianDto>();
            CreateMap<Musician, MusicianDtoWithListofBands>();
            CreateMap<Band, BandDtoOnlyName>();

        
            CreateMap<CreateMusicianDto, Musician>();

            CreateMap<CreateBandDto, Band>()
                 .ForMember(x => x.Description,
                  c => c.MapFrom(dto => new Description()
                  { Genres = dto.Genres }));

            CreateMap<UpdateBandDto, Band>();
            CreateMap<CreateAlbumDto, Album>();
            CreateMap<Album, AlbumDto>();
        }
    }
}
