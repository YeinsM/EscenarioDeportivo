using System.Collections.Generic;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public interface IRepositorioEquipo
    {
        IEnumerable<Equipo> ListarEquipos();
        List<Equipo> ListarEquiposList();
        List<Deportista> FiltrarDeportistasEquipo(Equipo equipo);
        List<TorneoEquipo> FiltrarinscripcionEquipos(Equipo equipo);
        bool CrearEquipo(Equipo equipo);
        bool ActualizarEquipo(Equipo equipo);
        bool EliminarEquipo(int Id);
        Equipo BuscarEquipo(Equipo _equipo);
        Equipo BuscarEquipoId(int? id);
    }
}