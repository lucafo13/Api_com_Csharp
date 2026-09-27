using Microsoft.EntityFrameworkCore;
using Pokemon.models;

namespace csharpBack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        public DbSet<Pokemons> pokemon {get; set;}
    }
}