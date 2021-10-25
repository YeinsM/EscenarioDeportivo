using System.Collections.Generic;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public interface IRepositorioEscenario
    {
        IEnumerable<Escenario> ListarEscenarios();
        bool CrearEscenario(Escenario escenario);
        bool ActualizarEscenario(Escenario escenario);
        bool EliminarEscenario(int id);
        Escenario BuscarEscenario(int id);
    }
}