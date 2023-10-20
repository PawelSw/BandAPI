using BandAPI.Models;

namespace BandAPI.Services
{
    public interface IAlbumService
    {
        int Create(CreateAlbumDto dto, int bandId);
        List<AlbumDto> GetAllAlbumsForOneBand(int bandId);
        AlbumDto GetAlbumById(int bandId, int albumId);
        void DeleteAllAlbums(int bandId);
        void DeleteOneAlbum(int bandId, int albumId);
    }
}