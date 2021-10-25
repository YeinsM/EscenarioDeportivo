using System;

namespace EscenarioDeportivo.Dominio
{
    public class EscuelaArbitro
    {
        public int Id { get; set; }
        public String Nit { get; set; }
        public String Nombre { get; set; }
        public String Resolucion { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Correo { get; set; }
        public int ArbitroId { get; set; }
    }
}