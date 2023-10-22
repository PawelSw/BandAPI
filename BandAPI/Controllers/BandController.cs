using AutoMapper;
using BandAPI.Entities;
using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("api/band")]
    [Authorize]
    public class BandsController : ControllerBase
    {

        private readonly IBandService _bandService;

        public BandsController(IBandService bandService)
        {
            _bandService = bandService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BandDto>> GetAllBands()
        {
            var result = _bandService.GetBands();
            return Ok(result);

        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<BandDto> GetById([FromRoute] int id)
        {
            var band = _bandService.GetBandById(id);

            return Ok(band);

        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateBand([FromBody] CreateBandDto createBandDto)
        {
          
            int bandId = _bandService.Create(createBandDto);
            return Created($"/api/band/ {bandId}", null);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _bandService.Delete(id);
             return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateBandDto dto, [FromRoute] int id)
        {
            _bandService.Update(dto, id);
             return Ok();

        }

    }
}


