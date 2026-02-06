using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharachterApi.DTO;
using VideoGameCharachterApi.Models;
using VideoGameCharachterApi.Services;

namespace VideoGameCharachterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharachtersController(ICharachterService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<CharachterResponse>>> GetCharachters()
            => Ok(await service.GetCharachtersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Charachter>> GetCharachterById(int id)
        {
            var charachter = await service.GetCharachterByIdAsync(id);
            if (charachter is null)
                return NotFound("Charachter not found");
            return Ok(charachter);
        }
        [HttpPost]
        public async Task<ActionResult<CharachterResponse>> AddCharachter(CreateCharachterRequest charachter)
        {
            var createdCharachter = await service.AddCharachterAsync(charachter);
            return CreatedAtAction(nameof(GetCharachterById), new { id = createdCharachter.Id }, createdCharachter);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharachter(int id, UpdateCharachterRequest charachter)
        {
            var isUpdated = await service.UpdateCharachterAsync(id, charachter);
            if (!isUpdated)
                return NotFound("Charachter not found");
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharachter(int id)
        {
            var isDeleted = await service.DeleteCharachterAsync(id);
            if (!isDeleted)
                return NotFound("Charachter not found");
            return NoContent();
        }
    }
}
