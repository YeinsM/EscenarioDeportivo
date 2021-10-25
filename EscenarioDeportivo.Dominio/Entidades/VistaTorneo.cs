using System;
using System.Collections.Generic;

namespace EscenarioDeportivo.Dominio
{
    public class VistaTorneo
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Categoria { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public String Tipo { get; set; }
        public String NombreMunicipio { get; set; }
    }
}