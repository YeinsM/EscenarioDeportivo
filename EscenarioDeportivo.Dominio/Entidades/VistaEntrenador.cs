using System;
using System.Collections.Generic;

namespace EscenarioDeportivo.Dominio
{
    public class VistaEntrenador
    {
        public int Id { get; set; }
        public String Documento { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Genero { get; set; }
        public String DisciplinaDeportiva { get; set; }
        public String NombreEquipo { get; set; }
        public String DisciplinaEquipo { get; set; }
    }
}