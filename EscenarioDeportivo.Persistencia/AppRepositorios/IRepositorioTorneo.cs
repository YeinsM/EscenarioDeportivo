using System.Collections.Generic;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public interface IRepositorioTorneo
    {
        bool CrearTorneo(Torneo torneo);
        bool ActualizarTorneo(Torneo torneo);
        bool EliminarTorneo(int id);
        Torneo BuscarTorneoId(int? id);
        Torneo BuscarTorneo(Torneo torneo);
        IEnumerable<Torneo> ListarTorneos();
        List<Torneo> ListarTorneosList();
        List<TorneoEquipo> FiltrarInscripcionesTorneo(Torneo torneo);
    }
}