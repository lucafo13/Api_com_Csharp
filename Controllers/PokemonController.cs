using csharpBack.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}