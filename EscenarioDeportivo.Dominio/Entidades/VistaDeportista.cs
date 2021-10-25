using System;
using System.Collections.Generic;

namespace EscenarioDeportivo.Dominio
{
    public class VistaDeportista
    {
        public int Id { get; set; }
        public String Documento { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Genero { get; set; }
        public String Rh { get; set; }
        public String EPS { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Disciplina { get; set; }
        public String Direccion { get; set; }
        public int EquipoId { get; set; }
        public String EquipoNombre { get; set; }
        public String EquipoDisciplina { get; set; }
    }
}