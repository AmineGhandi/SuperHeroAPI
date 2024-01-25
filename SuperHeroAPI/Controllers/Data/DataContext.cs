using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Controllers.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Superhero> SuperHeroes => Set<Superhero>();


    }
}
