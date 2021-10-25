using System;
using System.Collections.Generic;

namespace EscenarioDeportivo.Dominio
{
    public class VistaEquipo
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int CantidadDeportistas { get; set; }
        public String Disciplina { get; set; }
        public String PatrocinadorIdentificacion { get; set; }
        public String PatrocinadorNombre { get; set; }
    }
}