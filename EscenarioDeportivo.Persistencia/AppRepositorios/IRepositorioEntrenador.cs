using System.Collections.Generic;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public interface IRepositorioEntrenador
    {
        IEnumerable<Entrenador> ListarEntrenadores();
        bool CrearEntrenador(Entrenador entrenador);
        bool ActualizarEntrenador(Entrenador entrenador);
        bool EliminarEntrenador(string docEntrenador);
        Entrenador BuscarEntrenador(string docEntrenador);
    }
}