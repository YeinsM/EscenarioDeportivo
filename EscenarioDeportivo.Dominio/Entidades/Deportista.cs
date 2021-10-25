using System;
using System.ComponentModel.DataAnnotations;

namespace EscenarioDeportivo.Dominio
{
    public class Deportista
    {
        public int Id { get; set; }
        [Required(ErrorMessage="El documento es obligatorio")]
        [Display(Name = "Documento", Prompt = "Digite el documento")]
        [StringLength(20, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        public String Documento { get; set; }
        [Required(ErrorMessage="El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        [Display(Name = "Nombres", Prompt = "Digite el nombre")]
        public String Nombres { get; set; }
        [Required(ErrorMessage="El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        [Display(Name = "Apellidos", Prompt = "Digite el apellido")]
        public String Apellidos { get; set; }
        [Required(ErrorMessage="Seleccionar el género es obligatorio")]
        public String Genero { get; set; }
        [Required(ErrorMessage="El Rh es obligatorio")]
        [StringLength(10, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracter", MinimumLength = 1)]
        [Display(Name = "Rh", Prompt = "Digite el Rh")]
        public String Rh { get; set; }
        [Required(ErrorMessage="La EPS es obligatoria")]
        [StringLength(100, ErrorMessage = "Por favor indicar una {0} válida de mínimo {2} caracter", MinimumLength = 2)]
        [Display(Name = "EPS", Prompt = "Digite la EPS")]
        public String EPS { get; set; }
        [Required(ErrorMessage="La Fecha de Nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage="La disciplina es obligatoria")]
        [StringLength(100, ErrorMessage = "Por favor indicar una {0} válida de mínimo {2} caracter", MinimumLength = 2)]
        public String Disciplina { get; set; }
        [Required(ErrorMessage="La dirección es obligatoria")]
        [StringLength(100, ErrorMessage = "Por favor indicar una {0} válida de mínimo {2} caracter", MinimumLength = 2)]
        public String Direccion { get; set; }
        public int EquipoId { get; set; }
    }
}