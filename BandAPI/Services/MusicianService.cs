using AutoMapper;
using BandAPI.Entities;
using BandAPI.Exceptions;
using BandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BandAPI.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly BandDbContext _dbContext;
        private readonly IMapper _mapper;
        public MusicianService(BandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int CreateMusician(int bandId, CreateMusicianDto dto)
        {
            var band = GetBandById(bandId);

            var musicianEntity = _mapper.Map<Musician>(dto);

            band.Musicians.Add(musicianEntity);
            _dbContext.Musicians.Add(musicianEntity);
            _dbContext.SaveChanges();

            return musicianEntity.Id;

        }

        public void DeleteChosenMusician(int bandId, int musicianId)
        {
            var band = GetBandById(bandId);
            var musician = band.Musicians.FirstOrDefault(x => x.Id == musicianId);
            if (musician == null)
            {
                throw new NotFoundException("Musician not found");
            }

            band.Musicians.Remove(musician);
            _dbContext.Musicians.Remove(musician);
            _dbContext.SaveChanges();

        }
        public List<MusicianDtoWithListofBands> GetAllMusicians()
        {
            var musiciansEntity = _dbContext.Musicians.Include(x => x.Bands).ToList();
            var musiciansDto = _mapper.Map<List<MusicianDtoWithListofBands>>(musiciansEntity);
            return musiciansDto;


        }



        //public List<AlbumDto> GetAllAlbumsForOneBand(int bandId)
        //{
        //    var band = GetBandById(bandId);

        //    var allAlbums = _mapper.Map<List<AlbumDto>>(band.Albums);
        //    return allAlbums;

        //}
        private Band GetBandById(int bandId)
        {
            var band = _dbContext.Bands
                .Include(x => x.Musicians)
                .FirstOrDefault(x => x.Id == bandId);
            if (band == null)
            {
                throw new NotFoundException("Band not found");
            }
            return band;
        }
    }
}
