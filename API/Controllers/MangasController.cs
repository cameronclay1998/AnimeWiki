using Application.Mangas;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MangasController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(MangaDto dto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Dto = dto }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, MangaDto dto)
        {
            return HandleResult(await Mediator.Send(new Edit.Command { Id = id, Dto = dto }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}