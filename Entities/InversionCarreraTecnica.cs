using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiKalum.Entities
{
    public class InversionCarreraTecnica
    {
        public string InversionId { get; set; }
        public string CarreraId {get; set; }

        [Column(TypeName = "decimal(18,4)")]

        public decimal MontoInscripcion {get; set; }
        public int NumeroPagos {get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal MontoPago {get; set; }
        public virtual CarreraTecnica CarreraTecnica {get; set; }
     
    }
}