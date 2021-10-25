using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EscenarioDeportivo.Dominio
{
    public class Equipo
    {
        public int Id { get; set; }
        [Required(ErrorMessage="El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        [Display(Name = "Nombre", Prompt = "Digite el nombre")]
        public String Nombre { get; set; }
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números positivos")]
        [Required(ErrorMessage="La cantidad es obligatoria")]
        public int CantidadDeportistas { get; set; }
        [Required(ErrorMessage="La disciplina es obligatoria")]
        [StringLength(100, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        [Display(Name = "Nombre", Prompt = "Digite la disciplina")]
        public String Disciplina { get; set; }
        [Required(ErrorMessage="Seleccionar el Patrocinador es obligatorio")]
        public int PatrocinadorId { get; set; }
        public Entrenador Entrenador { get; set; }
        public List<TorneoEquipo> TorneoEquipos { get; set; }
        public List<Deportista> Deportistas { get; set; }
    }
}