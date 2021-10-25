using System;
using System.Collections.Generic;

namespace EscenarioDeportivo.Dominio
{
    public class Escenario
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Horario { get; set; }
        public int TorneoId { get; set; }
        public List<Cancha> Canchas { get; set; }
    }
}