using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : ControllerBase
    {
        private readonly MiDbContext _dbContext;

        public PerfilController(MiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ObtenerPerfiles()
        {
            var perfiles = _dbContext.Perfiles.ToList();
            return Ok(perfiles);
        }

        [HttpPost]
        public IActionResult CrearPerfil([FromBody] Perfil perfil)
        {
            _dbContext.Perfiles.Add(perfil);
            _dbContext.SaveChanges();
            return Ok(perfil);
        }
    }
}
