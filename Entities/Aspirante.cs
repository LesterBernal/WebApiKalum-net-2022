namespace WebApiKalum.Entities
{
    public class Aspirante
    {
      
        public string NoExpediente {get; set; }
        public string Apellidos {get; set; }
        public string Nombres {get; set; }
        public string Direccion {get; set; }
        public string Telefono {get; set; }
        public string Email {get; set; }

        public string Estatus {get; set; }
        public string CarreraId {get; set; }

        public string JornadaId {get; set; }

        public string ExamenId {get; set; }
        public CarreraTecnica CarreraTecnica {get; set; }
        public Jornada Jornada {get; set; }
        public ExamenAdmision ExamenAdmision {get; set; }
        public virtual List<ResultadoExamenAdmision> ResultadoExamenAdmisiones { get; set; }
        public virtual List<InscripcionPago> InscripcionPagos { get; set; }
      
    }
}