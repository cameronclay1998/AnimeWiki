using Application.Animes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnimeDto animeDto)
        {
            return HandleResult(await Mediator.Send(new Create.Command { AnimeDto = animeDto }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(AnimeDto animeDto, Guid id)
        {
            return HandleResult(await Mediator.Send(new Edit.Command { AnimeDto = animeDto, Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}