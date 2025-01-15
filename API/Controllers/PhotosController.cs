using Application.Photos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotosController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Add.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpDelete("{photoId}")]
        public async Task<IActionResult> Delete(string photoId, Guid animeId)
        {
            return HandleResult(await Mediator.Send(new Delete.Command{ PhotoId = photoId, AnimeId = animeId }));
        }
    }
}