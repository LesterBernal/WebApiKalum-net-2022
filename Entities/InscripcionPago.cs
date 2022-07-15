using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiKalum.Entities
{
    public class InscripcionPago
    {
         public string BoletaPago { get; set; }
        public string NoExpediente {get; set; }
        public string Anio {get; set; }
        public DateTime FechaPago {get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal Monto {get; set; }
        public Aspirante Aspirante {get; set; }
        
    }
}