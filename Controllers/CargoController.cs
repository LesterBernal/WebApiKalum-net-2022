using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiKalum.Entities;

namespace WebApiKalum.Controllers
{
    [ApiController]
    [Route("v1/kalumManagement/Cargos")]
    public class CargoController : ControllerBase
    {
        private readonly KalumDbContext DbContext;
        private readonly ILogger<CargoController> Logger;
        public CargoController(KalumDbContext _DbContext, ILogger<CargoController> _Logger)
        {
            this.DbContext = _DbContext;
            this.Logger = _Logger;
        }

        [HttpGet]

        public async Task<ActionResult<List<Cargo>>> Get()
        {
            List<Cargo> cargos = null;
            Logger.LogDebug("Iniciando proceso de consulta de Cargos en la base de datos");
            cargos = await DbContext.Cargo.Include(c => c.CuentaXCobrars).ToListAsync();
                        
                        
            if(cargos == null || cargos.Count == 0)
            {
                Logger.LogWarning("No Existe en Cargos");
                return new NoContentResult();
            }
            Logger.LogInformation("Se ejecuto la peticion de forma exitosa");
            return Ok(cargos);

        }
        [HttpGet("{id}", Name = "GetCargo")]
        public async Task<ActionResult<Alumno>> GetCargo(string id)
        {
            Logger.LogDebug("Inciando el proceso de busqueda con el id " + id);
            var cargo = await DbContext.Cargo.Include(c => c.CuentaXCobrars).FirstOrDefaultAsync(ct => ct.CargoId == id);
            if (cargo == null)
            { Logger.LogWarning("No existe Cargo con el id " + id);
                return new NoContentResult();

            }
            Logger.LogInformation("Finalizado el proceso de busqueda de forma exitosa");
            return Ok(cargo);

        

        }


    }
}