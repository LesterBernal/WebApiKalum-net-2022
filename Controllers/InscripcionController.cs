using Microsoft.AspNetCore.Mvc;
using WebApiKalum.Dtos;
using WebApiKalum.Entities;

namespace WebApiKalum.Controllers
{
    [ApiController]
    [Route("v1/kalumManagement/Inscripciones")]
    public class InscripcionController : ControllerBase
    {
        private readonly KalumDbContext DbContext;
        private readonly ILogger<InscripcionController> Logger;
        public InscripcionController(KalumDbContext _DbContext, ILogger<InscripcionController> _Logger)
        {
            this.Logger = _Logger;
            this.DbContext = _DbContext;
        }
        [HttpPost("Enrollments")]

        public async Task<ActionResult<ResponseEnrollmentDTO>> EnrollmentCreateAsync([FromBody] EnrollmentDTO value)
        {
            Aspirante aspirante = DbContext.Aspirante.FirstOrDefault(a => a.NoExpediente === value.NoExpediente);
        
    }
}
}