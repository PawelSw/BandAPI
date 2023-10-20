using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BandAPI.Controllers
{
    [ApiController]
   
    public class MusicianController : ControllerBase
    {
        private readonly IMusicianService _musicianService;
        public MusicianController(IMusicianService musicianService)
        {
            _musicianService = musicianService;
        }

        [HttpPost("api/band/{bandId}/musician")]
        public ActionResult Create([FromRoute] int bandId, [FromBody] CreateMusicianDto dto)
        {
            var newMusicianId = _musicianService.CreateMusician(bandId,dto);
            return Created($"/api/band/{bandId}/musician/{newMusicianId}", null);
        } 

        [HttpDelete("api/band/{bandId}/musician/{musicianId}")]
        public ActionResult Delete([FromRoute] int bandId, [FromRoute] int musicianId)
        {
            _musicianService.DeleteChosenMusician(bandId,musicianId);
            return NoContent();
        }

        [HttpGet("api/musicians")]
        public ActionResult DisplayAllMusicians() 
        { 
            var list = _musicianService.GetAllMusicians();
            return Ok(list);
        
        }

    }
}
