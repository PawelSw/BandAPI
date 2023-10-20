using BandAPI.Models;

namespace BandAPI.Services
{
    public interface IMusicianService
    {
        int CreateMusician(int bandId, CreateMusicianDto dto);
        void DeleteChosenMusician(int bandId, int musicianId);
        List<MusicianDtoWithListofBands> GetAllMusicians();
    }
}