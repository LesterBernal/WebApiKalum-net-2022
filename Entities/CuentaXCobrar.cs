using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiKalum.Entities
{
    public class CuentaXCobrar
    {
        public string CargoI { get; set; }
        public string Anio {get; set; }
        public string Carne {get; set; }
        public string CargoId {get; set; }
        public string Descripcion {get; set; }
        public DateTime FechaCargo {get; set; }
        public DateTime FechaAplica {get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Monto {get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Mora {get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Descuento {get; set; }
       public virtual Cargo Cargo {get; set; }

       public virtual Alumno  Alumno {get; set; }
    }
}