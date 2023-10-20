using AutoMapper;
using BandAPI.Entities;
using BandAPI.Exceptions;
using BandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BandAPI.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly BandDbContext _dbContext;
        private readonly IMapper _mapper;
        public AlbumService(BandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreateAlbumDto dto, int bandId)
        {
            var band = GetBandById(bandId);

            var albumEntity = _mapper.Map<Album>(dto);
            albumEntity.BandId = bandId;

            _dbContext.Albums.Add(albumEntity);
            _dbContext.SaveChanges();

            return albumEntity.Id;

        }

        public List<AlbumDto> GetAllAlbumsForOneBand(int bandId)
        {
            var band = GetBandById(bandId);

            var allAlbums = _mapper.Map<List<AlbumDto>>(band.Albums);
            return allAlbums;

        }

        public AlbumDto GetAlbumById(int bandId, int albumId) 
        {
            var band = GetBandById(bandId);

            var album = _dbContext.Albums.FirstOrDefault(x => x.Id == albumId);
            if (album == null || album.BandId != bandId)
            {
                throw new NotFoundException("Album not found");
            }

            var albumDto = _mapper.Map<AlbumDto>(album);
            return albumDto;
        }

        public void DeleteAllAlbums (int bandId)
        {
            var band = GetBandById(bandId);
            _dbContext.RemoveRange(band.Albums);
            _dbContext.SaveChanges();
        }

        public void DeleteOneAlbum (int bandId, int albumId)
        {
            var band = GetBandById(bandId);
            var album = band.Albums.FirstOrDefault(x => x.Id == albumId);
            if (album == null || album.BandId != bandId)
            {
                throw new NotFoundException("Album not found");
            }
            _dbContext.Albums.Remove(album);
            _dbContext.SaveChanges();

            

        }

        private Band GetBandById(int bandId) 
        {
            var band = _dbContext.Bands
                .Include(x => x.Albums)
                .FirstOrDefault(x => x.Id == bandId);
            if (band == null)
            {
                throw new NotFoundException("Band not found");
            }
            return band;
        }

    }
}
