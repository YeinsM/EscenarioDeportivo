using System.Collections.Generic;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public interface IRepositorioTorneoEquipo
    {
        bool CrearTorneoEquipo(TorneoEquipo torneoEquipo);
        bool EliminarTorneoEquipo(TorneoEquipo torneoEquipo);
        TorneoEquipo BuscarTorneoEquipoId(int ETorneoId,int EEquipoId);
        IEnumerable<TorneoEquipo> ListarTorneosEquipos();
    }
}