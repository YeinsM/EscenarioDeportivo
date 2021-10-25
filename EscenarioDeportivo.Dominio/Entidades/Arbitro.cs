using System;
using System.Collections.Generic;

namespace EscenarioDeportivo.Dominio
{
    public class Arbitro
    {
        public int Id { get; set; }
        public String Documento { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Genero { get; set; }
        public String Celular { get; set; }
        public String Correo { get; set; }
        public String Disciplina { get; set; }
        public int TorneoId { get; set; }
        public List<EscuelaArbitro> Escuelas { get; set; }
    }
}