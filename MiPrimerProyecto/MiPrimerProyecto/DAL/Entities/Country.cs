using System.ComponentModel.DataAnnotations;

namespace MiPrimerProyecto.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "Pais")]//Para identificar el nombre mas facil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]//Longitud del nombre
        [Required(ErrorMessage = "El campo pais es obligatorio")]//Campo obligatorio
        public string Name { get; set; }

        [Display(Name = "Estados/Departamentos")]
        public ICollection<State>? States { get; set; }
    }
}
