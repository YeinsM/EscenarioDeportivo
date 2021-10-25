using System.Collections.Generic;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public interface IRepositorioPatrocinador
    {
        IEnumerable<Patrocinador> ListarPatrocinadores();
        List<Patrocinador> ListarPatrocinadoresList();
        List<Equipo> FiltrarPatrocinadorEquipos(Patrocinador patrocinador);
        bool CrearPatrocinador(Patrocinador patrocinador);
        bool ActualizarPatrocinador(Patrocinador patrocinador);
        bool EliminarPatrocinador(string identPatrocinador);
        Patrocinador BuscarPatrocinador(string identPatrocinador);
    }
}