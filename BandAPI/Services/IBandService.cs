using BandAPI.Entities;
using BandAPI.Models;
using System.Security.Claims;

namespace BandAPI.Services
{
    public interface IBandService
    {
        BandDto GetBandById(int bandId);
        IEnumerable<BandDto> GetBands();
        int Create(CreateBandDto dto);
        void Delete(int id);
        void Update(UpdateBandDto dto, int bandId);

    }
}