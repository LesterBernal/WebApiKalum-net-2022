using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiKalum.Entities;

namespace WebApiKalum.Controllers
{

    [ApiController]
    [Route("v1/kalumManagement/Jornadas")]
    public class JornadaController : ControllerBase
    {
        
        private readonly KalumDbContext DbContext;
        private readonly ILogger<JornadaController> Logger;
        public JornadaController(KalumDbContext _DbContext, ILogger<JornadaController> _Logger)
        {
            this.DbContext = _DbContext;
            this.Logger = _Logger;
        }

        [HttpGet]

        public async Task<ActionResult<List<Jornada>>> Get()
        {
            List<Jornada> jornadas = null;
            Logger.LogDebug("Iniciando proceso de consulta de Jornadas en la base de datos");
            jornadas = await DbContext.Jornada.Include(c => c.Aspirantes).Include(c => c.Inscripciones).ToListAsync();
                        
                        
            if(jornadas == null || jornadas.Count == 0)
            {
                Logger.LogWarning("No Existe en Jornada");
                return new NoContentResult();
            }
            Logger.LogInformation("Se ejecuto la peticion de forma exitosa");
            return Ok(jornadas);

        }
        [HttpGet("{id}", Name = "GetJornada")]
        public async Task<ActionResult<CarreraTecnica>> GetJornada(string id)
        {
            Logger.LogDebug("Inciando el proceso de busqueda con el id " + id);
            var jornada = await DbContext.Jornada.Include(c => c.Aspirantes).Include(c => c.Inscripciones).FirstOrDefaultAsync(ct => ct.JornadaId == id);
            if (jornada == null)
            { Logger.LogWarning("No existe la Jornada con el id " + id);
                return new NoContentResult();

            }
            Logger.LogInformation("Finalizado el proceso de busqueda de forma exitosa");
            return Ok(jornada);

        

        }


        

    }

    
}