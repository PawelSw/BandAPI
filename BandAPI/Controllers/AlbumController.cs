using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("api/band/{bandId}/album")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateAlbumDto dto, [FromRoute] int bandId)
        {
            var newAlbumId = _albumService.Create(dto, bandId);
            return Created($"/api/band/{bandId}/album/{newAlbumId}", null);
        }

        [HttpGet]
        public ActionResult GetAllAlbumsForBand([FromRoute] int bandId)
        {
            var bands = _albumService.GetAllAlbumsForOneBand(bandId);
            return Ok(bands);
        }

        [HttpGet("{albumId}")]
        public ActionResult GetAllAlbumsForBand([FromRoute] int bandId, [FromRoute] int albumId)
        {
            var album = _albumService.GetAlbumById(bandId, albumId);
            return Ok(album);
        }

        [HttpDelete]
        public ActionResult DeleteAllAlbumsFromOneBand([FromRoute] int bandId)
        {
            _albumService.DeleteAllAlbums(bandId);
            return NoContent();
        }

        [HttpDelete("{albumId}")]
        public ActionResult DeleteChosenAlbum([FromRoute]  int bandId, [FromRoute]  int albumId)
        {
            _albumService.DeleteOneAlbum(bandId, albumId);
            return NoContent();
        
        }


    }
}
