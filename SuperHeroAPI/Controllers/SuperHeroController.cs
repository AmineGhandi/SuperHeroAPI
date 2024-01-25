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

        [HttpPost]

        public async Task<ActionResult<List<Superhero>>> CreateSuperHeroes(Superhero hero)
        {
            _Context.SuperHeroes.Add(hero);
            await _Context.SaveChangesAsync();

            return Ok(await _Context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Superhero>>> UpdateSuperHeroes(Superhero hero)
        {
            var dbHero = await _Context.SuperHeroes.FindAsync(hero.Id);
            if (dbHero == null)
                return BadRequest("Hero's not there");
            

            dbHero.spName = hero.spName;
            dbHero.firstName = hero.firstName;
            dbHero.lastName = hero.lastName;
            dbHero.origin = hero.origin;

            await _Context.SaveChangesAsync();
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Superhero>>> DeleteSuperHeroes(int id)
        {
            var dbHero = await _Context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero's not there");

            _Context.SuperHeroes.Remove(dbHero); 
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }
    }
}
