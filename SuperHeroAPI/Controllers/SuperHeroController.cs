using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<List<Superhero>>> GetSuperHeroes()
        {
            return new List<Superhero>
            {
                new Superhero
                {
                        spName = "Spider Man",
                        firstName = "Peter",
                        lastName = "Parker",
                        origin = "NYC"
                }
            };
        }
    }
}
