using System;
using System.Collections.Generic;

namespace EscenarioDeportivo.Dominio
{
    public class VistaTorneoEquipo
    {
        public int TorneoId { get; set; }
        public String TorneoNombre { get; set; }
        public String TorneoTipo { get; set ;}
        public int EquipoId { get; set; }
        public String EquipoNombre { get; set; }
        public String EquipoDisciplina { get; set; }
    }
}