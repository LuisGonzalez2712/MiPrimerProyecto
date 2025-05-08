using System.ComponentModel.DataAnnotations;

namespace MiPrimerProyecto.DAL.Entities
{
    public class AuditBase
    {
        [Key]//PK
        [Required]//Significa que el campo es obligatorio
        public virtual Guid Id { get; set; }// este sera el Pk de todas las tablas

        public virtual DateTime? CreatedDate { get; set; }// para guardar todo registro nuevo con su date

        public virtual DateTime? ModifiedDate { get; set; }//para guardar todo registro que se modifico con su date
    }
}
