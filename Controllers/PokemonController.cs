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
            return Ok(lista);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAll(Pokemons pokemon)
        {
            var find = await _appDbContext.pokemon.FirstOrDefaultAsync(x => x.Id == pokemon.Id);
            if(find == null)
            {
                return NotFound(404);

            }
            find.Nome = pokemon.Nome;
            find.tipo = pokemon.tipo;
            var lista = await _appDbContext.pokemon.ToListAsync();
            return Ok(lista);

            
        }
        [HttpPatch("nome/{Id}")]
        public async Task<ActionResult> UpdateName(string nome, int Id)
        {
            var find = await _appDbContext.pokemon.FindAsync(Id);
            if(find == null)
            {
                return NotFound(404);
            }
            find.Nome = nome;
            await _appDbContext.SaveChangesAsync();
            return Ok(find);
        }
        [HttpPatch("tipo/{Id}")]
        public async Task<ActionResult> UpdateTipo(string tipo, int Id)
        {
            var find = await _appDbContext.pokemon.FindAsync(Id);
            if(find == null)
            {
                return NotFound(404);
            }
            find.Nome = tipo;
            
            await _appDbContext.SaveChangesAsync();
            return Ok(find);
        }
        [HttpGet("tipo/{tipo}")]
        public async Task<ActionResult> FindTipo(string tipo)
        {
            var find = await _appDbContext.pokemon.Where(x => x.tipo == tipo).ToListAsync();
            if(find == null)
            {
                return NotFound();
            }
            return Ok(find);
        }
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> FindNome(string nome)
        {
            var find = await _appDbContext.pokemon.Where(x => x.Nome == nome).ToListAsync();
            if(find == null)
            {
                return NotFound();
            }
            return Ok(find);
        }
    }
}