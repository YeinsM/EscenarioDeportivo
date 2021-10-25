using System;

namespace EscenarioDeportivo.Dominio
{
    public class Cancha
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Disciplina { get; set; }
        public String Estado { get; set; }
        public int CapacidadEspectadores { get; set; }
        public double Medidas { get; set; }
        public int EscenarioId { get; set; }
    }
}