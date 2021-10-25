using System;
using System.ComponentModel.DataAnnotations;

namespace EscenarioDeportivo.Dominio
{
    public class TorneoEquipo
    {
        [Required(ErrorMessage="Seleccionar el Torneo es obligatorio")]
        public int TorneoId { get; set; }
        [Required(ErrorMessage="Seleccionar el Equipo es obligatorio")]
        public int EquipoId { get; set; }
        public Torneo Torneo { get; set; }
        public Equipo Equipo { get; set; }
    }
}