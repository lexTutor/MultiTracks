using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTEFDataAccess.Infrastructure.Interfaces;
using MTEFDataAccess.Model;

namespace Multitracks.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet(nameof(List))]
        public IActionResult List([FromQuery] SearchRequest searchRequest)
        {
            var result = _songService.ListSongs(searchRequest);

            return Ok(result);
        }
    }
}
