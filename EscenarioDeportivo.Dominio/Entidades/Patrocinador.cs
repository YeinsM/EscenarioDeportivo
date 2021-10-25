using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EscenarioDeportivo.Dominio
{
    public class Patrocinador
    {
        public int Id { get; set; }
        [Required(ErrorMessage="La identificación es obligatorio")]
        [Display(Name = "Identificacion", Prompt = "Digite la identificacion")]
        [StringLength(20, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        public String Identificacion { get; set; }
        [Required(ErrorMessage="El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        [Display(Name = "Nombre", Prompt = "Digite el nombre")]
        public String Nombre { get; set; }
        [Required(ErrorMessage="Seleccionar el tipo es obligatorio")]
        public String TipoPersona { get; set; }
        [Required(ErrorMessage="La dirección es obligatorio")]
        [Display(Name = "Direccion", Prompt = "Digite la dirección")]
        public String Direccion { get; set; }
        [Display(Name = "Telefono", Prompt = "Digite el teléfono")]
        public String Telefono { get; set; }
        public List<Equipo> Equipos { get; set; }
    }
}