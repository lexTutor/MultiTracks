using Microsoft.AspNetCore.Mvc;
using MTEFDataAccess.Infrastructure.Interfaces;
using System.ComponentModel.DataAnnotations;
using static MTEFDataAccess.Model.Records;

namespace Multitracks.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add(CreateArtistRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _artistService.CreateArtist(request);

            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet(nameof(Search))]
        public async Task<IActionResult> Search([Required] string artistName)
        {
            var result = await _artistService.SearchArtist(artistName);

            return Ok(result);
        }
    }
}
