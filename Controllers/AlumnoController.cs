using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiKalum.Entities;

namespace WebApiKalum.Controllers
{
    [ApiController]
    [Route("v1/kalumManagement/Alumnos")]
    public class AlumnoController : ControllerBase
    {
        private readonly KalumDbContext DbContext;
        private readonly ILogger<AlumnoController> Logger;
        public AlumnoController(KalumDbContext _DbContext, ILogger<AlumnoController> _Logger)
        {
            this.DbContext = _DbContext;
            this.Logger = _Logger;
        }

        [HttpGet]

        public async Task<ActionResult<List<Alumno>>> Get()
        {
            List<Alumno> alumnos = null;
            Logger.LogDebug("Iniciando proceso de consulta de Alumnos en la base de datos");
            alumnos = await DbContext.Alumno.Include(c => c.Inscripciones).ToListAsync();
                        
                        
            if(alumnos == null || alumnos.Count == 0)
            {
                Logger.LogWarning("No Existe en Alumnos");
                return new NoContentResult();
            }
            Logger.LogInformation("Se ejecuto la peticion de forma exitosa");
            return Ok(alumnos);

        }
        [HttpGet("{id}", Name = "GetAlumno")]
        public async Task<ActionResult<Alumno>> GetAlumno(string id)
        {
            Logger.LogDebug("Inciando el proceso de busqueda con el id " + id);
            var alumno = await DbContext.Alumno.Include(c => c.Inscripciones).FirstOrDefaultAsync(ct => ct.Carne == id);
            if (alumno == null)
            { Logger.LogWarning("No existe Alumno con el id " + id);
                return new NoContentResult();

            }
            Logger.LogInformation("Finalizado el proceso de busqueda de forma exitosa");
            return Ok(alumno);

        

        }

        [HttpPost]

        public async Task<ActionResult<Alumno>> Post([FromBody] Alumno value)
        {
            Logger.LogDebug("Iniciando el proceso de agregar una alumno nuevo");
            value.Carne= Guid.NewGuid().ToString().ToUpper();
            await DbContext.Alumno.AddAsync(value);
            await DbContext.SaveChangesAsync();
            Logger.LogInformation("Finalizando el proceso de agregar Alumno");
            return new CreatedAtRouteResult("GetAlumno", new {id = value.Carne}, value);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Alumno>> Delete(string id)
        {
            Logger.LogDebug("Iniciando el proceso de eliminar Alumno");
            Alumno alumno = await DbContext.Alumno.FirstOrDefaultAsync(ct=> ct.Carne == id);
            if(alumno == null)
            {
                Logger.LogWarning($"No se econtro ninguna alumno con el id {id}");
                return NotFound();
            }
            else
            {
                DbContext.Alumno.Remove(alumno);
                await DbContext.SaveChangesAsync();
                Logger.LogInformation($"Se ha eliminado correctamente el alumno con el id {id}");
                return alumno;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Alumno value)
        {
            Logger.LogDebug($"Iniciando el proceso de actualziacion del alumno con el id {id}");
            Alumno alumno = await DbContext.Alumno.FirstOrDefaultAsync(ct => ct.Carne == id);
            if(alumno == null)
            {
                Logger.LogWarning($"No existe alumno con el ID {id}");
                return BadRequest();
            }
            alumno.Nombres = value.Nombres;
            DbContext.Entry(alumno).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            Logger.LogInformation("Los datos han sido actualizados correctamente");
            return NoContent();
        
        }


    }
}