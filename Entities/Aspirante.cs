using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using WebApiKalum.Helpers;

namespace WebApiKalum.Entities
{
    public class Aspirante //: IValidatableObject
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(12,MinimumLength = 12, ErrorMessage = "La cantidad minima de caracteres es {2} la maxima es {1} para el campo {0}")]
        [NoExpediente]
        public string NoExpediente {get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Apellidos {get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombres {get; set; }
       
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion {get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Telefono {get; set; }
        [EmailAddress(ErrorMessage = "El correo electronico no es valido")]
        public string Email {get; set; }

        public string Estatus {get; set; } = "NO ASIGNADO";
        public string CarreraId {get; set; }

        public string JornadaId {get; set; }

        public string ExamenId {get; set; }
        public CarreraTecnica CarreraTecnica {get; set; }
        public Jornada Jornada {get; set; }
        public ExamenAdmision ExamenAdmision {get; set; }
       
        public virtual List<ResultadoExamenAdmision> ResultadoExamenAdmisiones { get; set; }
        public virtual List<InscripcionPago> InscripcionPagos { get; set; }


       /* public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //bool expedientevalid = false ;
            if (!string.IsNullOrEmpty(NoExpediente))
            {
               if(!NoExpediente.Contains("-"))
               {
                    yield return new ValidationResult("El numero de expediente es invalido, no contiene un '-'", new string[]{nameof(NoExpediente)});                
               }
               else
               {
                    int guion = NoExpediente.IndexOf("-"); 
                    string exp = NoExpediente.Substring(0,guion);
                    string numero = NoExpediente.Substring(guion+1, NoExpediente.Length - 4);
                    if(!exp.ToUpper().Equals("EXP") || !Information.IsNumeric(numero))
                        {
                             yield return new ValidationResult("El numero de expediente no contiene la nomenclatura adecuada", new string[]{nameof(NoExpediente)});                
                        }             
                }
            }
        }*/
    }
}