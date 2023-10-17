using BandAPI.Models;

namespace BandAPI.Services
{
    public interface IBandService
    {
        BandDto GetBandById(int bandId);
        IEnumerable<BandDto> GetBands();
        int Create(CreateBandDto dto);
        bool Delete(int id);
        bool Update(UpdateBandDto dto, int bandId);

    }
}