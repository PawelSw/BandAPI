using AutoMapper;
using BandAPI.Entities;
using BandAPI.Exceptions;
using BandAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BandAPI.Services
{
    public class BandService : IBandService
    {
        private readonly BandDbContext _bandsContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BandService> _logger;
        public BandService(BandDbContext bandsContext, IMapper mapper, ILogger<BandService> logger)
        {
            _bandsContext = bandsContext;
            _mapper = mapper;
            _logger = logger;   
        }
        public IEnumerable<BandDto> GetBands()
        {
            var bands = _bandsContext.Bands
                .Include(x => x.Albums)
                .Include(x => x.Musicians)
                .Include(x => x.Description)
                .ToList();

            var bandsDto = _mapper.Map<List<BandDto>>(bands);
            return bandsDto;

        }
        public BandDto GetBandById(int bandId)
        {
            var bandEntity = _bandsContext.Bands
                .Include(x => x.Albums)
                .Include(x => x.Musicians)
                .Include(x => x.Description)
                .Where(x => x.Id == bandId)
                .FirstOrDefault();

            if (bandEntity == null)
            {
                throw new NotFoundException("Band not found");
            }

            var bandDto = _mapper.Map<BandDto>(bandEntity);
            return bandDto;
        }

        public int Create(CreateBandDto dto)
        {
            var bandEntity = _mapper.Map<Band>(dto);
            _bandsContext.Add(bandEntity);
            _bandsContext.SaveChanges();
            return bandEntity.Id;

        }

        public void Delete(int id)
        {
            _logger.LogError($"Band with id {id} deleting action invoked.");
            var bandToDelete = _bandsContext.Bands.FirstOrDefault(x => x.Id == id);

            if (bandToDelete != null)
            {
                _bandsContext.Remove(bandToDelete);
                _bandsContext.SaveChanges();
            
                
            }
            throw new NotFoundException("Band not found");

        }
        public void Update(UpdateBandDto dto, int bandId)
        {
            var bandEntity = _bandsContext.Bands.Where(x => x.Id == bandId).FirstOrDefault();
            if (bandEntity == null)
            {
                throw new NotFoundException("Band not found");
            }
            bandEntity.Name = dto.Name;
            bandEntity.DateOfFoundation = dto.DateOfFoundation;
            _bandsContext.SaveChanges();

        }

    }
}
