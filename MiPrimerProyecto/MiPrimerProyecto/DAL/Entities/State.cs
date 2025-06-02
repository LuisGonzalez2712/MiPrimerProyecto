using System.ComponentModel.DataAnnotations;

namespace MiPrimerProyecto.DAL.Entities
{
    public class State : AuditBase
    {

        [Display(Name = "Estado/Departamento")]//Para identificar el nombre mas facil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]//Longitud del nombre
        [Required(ErrorMessage = "El campo pais es obligatorio")]//Campo obligatorio
        public string Name { get; set; }

        //Asi relaciono dos tablas en EF Core
        [Display(Name = "Pais")]
        public Country? Country { get; set; }

        //FK
        [Display(Name = "Id Pais")]
        public Guid? CountryId { get; set; }



    }
}
