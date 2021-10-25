using System;
using System.ComponentModel.DataAnnotations;

namespace EscenarioDeportivo.Dominio
{
    public class Entrenador
    {
        public int Id { get; set; }
        [Required(ErrorMessage="El documento es obligatorio")]
        [StringLength(20, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        [Display(Name = "Documento", Prompt = "Digite el documento")]
        public String Documento { get; set; }
        [Required(ErrorMessage="El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        public String Nombres { get; set; }
        [Required(ErrorMessage="El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        public String Apellidos { get; set; }
        [Required(ErrorMessage="Seleccionar el género es obligatorio")]
        public String Genero { get; set; }
        [Required(ErrorMessage="La disciplina es obligatoria")]
        [StringLength(100, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        public String DisciplinaDeportiva { get; set; }
        public int EquipoId { get; set; }
    }
}