using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharachterApi.Models;
using VideoGameCharachterApi.Services;

namespace VideoGameCharachterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharachtersController(ICharachterService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Charachter>>> GetCharachters()
            => Ok(await service.GetCharachtersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Charachter>> GetCharachterById(int id)
        {
            var charachter = await service.GetCharachterByIdAsync(id);
            if (charachter is null)
                return NotFound("Charachter not found");
            return Ok(charachter);
        }
    }
}
