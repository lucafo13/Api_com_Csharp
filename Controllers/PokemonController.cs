using csharpBack.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Pokemon.models;
namespace csharpBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public PokemonController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost]
        public async Task<ActionResult> addPokemon(Pokemons pokemonNew)
        {
            _appDbContext.pokemon.Add(pokemonNew);
            await _appDbContext.SaveChangesAsync();


            return Ok(pokemonNew);
        }
        [HttpGet]
        public async Task<ActionResult> ShowPokemon()
        {
            var lista = await _appDbContext.pokemon.ToListAsync();
            return Ok(lista);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteOne(int Id)
        {
            var finded = await _appDbContext.pokemon.FirstOrDefaultAsync(x => x.Id == Id);
            if (finded == null)
            {
                return NotFound("Deu ruim hein");

            }
            _appDbContext.pokemon.Remove(finded);
            await _appDbContext.SaveChangesAsync();
            var lista = await _appDbContext.pokemon.ToListAsync();
            return Ok("Aura");
        }
    }
}