using AutoMapper;
using BandAPI.Entities;
using BandAPI.Exceptions;
using BandAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static BandAPI.Authorization.ResourceAuthorizationRequirement;

namespace BandAPI.Services
{
    public class BandService : IBandService
    {
        private readonly BandDbContext _bandsContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BandService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public BandService(BandDbContext bandsContext, IMapper mapper, ILogger<BandService> logger, IAuthorizationService authorizationService,
            IUserContextService userContextService)
        {
            _bandsContext = bandsContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
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
            bandEntity.CreatedById = _userContextService.GetUserId;
            _bandsContext.Add(bandEntity);
            _bandsContext.SaveChanges();
            return bandEntity.Id;

        }

        public void Delete(int id)
        {
            _logger.LogError($"Band with id {id} deleting action invoked.");
            var bandToDelete = _bandsContext.Bands.FirstOrDefault(x => x.Id == id);

            if (bandToDelete == null)
            {
                throw new NotFoundException("Band not found");
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, bandToDelete,
              new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }
            _bandsContext.Remove(bandToDelete);
            _bandsContext.SaveChanges();
        }
        public void Update(UpdateBandDto dto, int bandId)
        {
            var bandEntity = _bandsContext.Bands.Where(x => x.Id == bandId).FirstOrDefault();
            if (bandEntity == null)
            {
                throw new NotFoundException("Band not found");
            }
            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, bandEntity,
              new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            bandEntity.Name = dto.Name;
            bandEntity.DateOfFoundation = dto.DateOfFoundation;
            _bandsContext.SaveChanges();

        }

    }
}
