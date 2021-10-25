using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EscenarioDeportivo.Dominio
{
    public class Municipio
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        [Display(Name = "Nombre", Prompt = "Digite el nombre")]
        public String Nombre { get; set; }
        public List<Torneo> Torneos { get; set; }
    }
}