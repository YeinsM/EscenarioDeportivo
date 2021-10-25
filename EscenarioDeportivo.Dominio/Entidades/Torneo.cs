using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EscenarioDeportivo.Dominio
{
    public class Torneo
    {
        public int Id { get; set; }
        [Required(ErrorMessage="El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        [Display(Name = "Nombre", Prompt = "Digite el nombre")]
        public String Nombre { get; set; }
        [Required(ErrorMessage="La categoría es obligatoria")]
        [StringLength(100, ErrorMessage = "Por favor indicar una {0} válida de mínimo {2} caracteres", MinimumLength = 2)]
        [Display(Name = "Categoria", Prompt = "Digite la categoría")]
        public String Categoria { get; set; }
        [Required(ErrorMessage="La Fecha Inicial es obligatoria")]
        public DateTime FechaInicial { get; set; }
        [Required(ErrorMessage="La Fecha Final es obligatoria")]
        public DateTime FechaFinal { get; set; }
        [Required(ErrorMessage="El tipo es obligatorio")]
        [StringLength(100, ErrorMessage = "Por favor indicar un {0} válido de mínimo {2} caracteres", MinimumLength = 2)]
        [Display(Name = "Tipo", Prompt = "Digite el tipo de torneo")]
        public String Tipo { get; set; }
        [Required(ErrorMessage="Seleccionar el Municipio es obligatorio")]
        public int MunicipioId { get; set; }
        public List<TorneoEquipo> TorneoEquipos { get; set; }
        public List<Arbitro> Arbitros { get; set; }
        public List<Escenario> Escenarios { get; set; }
    }
}