using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Controllers.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _Context;
        public SuperHeroController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Superhero>>> GetSuperHeroes()
        {
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }
    }
}
