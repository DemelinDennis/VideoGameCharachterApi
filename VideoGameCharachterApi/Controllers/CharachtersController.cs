using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharachterApi.Models;

namespace VideoGameCharachterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharachtersController : ControllerBase
    {
        static List<Charachter> charachters = new List<Charachter>() {
            new Charachter { Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Protagonist" },
            new Charachter { Id = 2, Name = "Link", Game = "The Legend of Zelda", Role = "Protagonist" },
            new Charachter { Id = 3, Name = "Master Chief", Game = "Halo", Role = "Protagonist" }
        };

        [HttpGet]
        public async Task<ActionResult<List<Charachter>>> GetCharachters() 
            => await Task.FromResult(Ok(charachters));
    }
}
