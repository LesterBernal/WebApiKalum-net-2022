using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiKalum.Entities;

namespace WebApiKalum.Controllers
{
    [ApiController]
    [Route("v1/kalumManagement/ExamenAdmisiones")]
    public class ExamenAdmisionController : ControllerBase
    {
        private readonly KalumDbContext DbContext;
        private readonly ILogger<ExamenAdmisionController> Logger;
        public ExamenAdmisionController(KalumDbContext _DbContext, ILogger<ExamenAdmisionController> _Logger)
        {
            this.DbContext = _DbContext;
            this.Logger = _Logger;
        }

        [HttpGet]

        public async Task<ActionResult<List<ExamenAdmision>>> Get()
        {
            List<ExamenAdmision> examenAdmisiones = null;
            Logger.LogDebug("Iniciando proceso de consulta de carreras tecnias en la base de datos");
            examenAdmisiones = await DbContext.ExamenAdmision.Include(c => c.Aspirantes).ToListAsync();
                        
                        
            if(examenAdmisiones == null || examenAdmisiones.Count == 0)
            {
                Logger.LogWarning("No Existe en carreras tecnicas");
                return new NoContentResult();
            }
            Logger.LogInformation("Se ejecuto la peticion de forma exitosa");
            return Ok(examenAdmisiones);

        }
        [HttpGet("{id}", Name = "GetExamenAdmision")]
        public async Task<ActionResult<CarreraTecnica>> GetExamenAdmision(string id)
        {
            Logger.LogDebug("Inciando el proceso de busqueda con el id " + id);
            var examen = await DbContext.ExamenAdmision.Include(c => c.Aspirantes).FirstOrDefaultAsync(ct => ct.ExamenId == id);
            if (examen == null)
            { Logger.LogWarning("No existe la carrera tecnica con el id " + id);
                return new NoContentResult();

            }
            Logger.LogInformation("Finalizado el proceso de busqueda de forma exitosa");
            return Ok(examen);

        

        }


    }
}