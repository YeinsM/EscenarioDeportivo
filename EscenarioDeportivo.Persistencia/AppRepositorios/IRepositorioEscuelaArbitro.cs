using System.Collections.Generic;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public interface IRepositorioEscuelaArbitro
    {
        IEnumerable<EscuelaArbitro> ListarEscuelaArbitros();
        bool CrearEscuelaArbitro(EscuelaArbitro escuelaArbitro);
        bool ActualizarEscuelaArbitro(EscuelaArbitro escuelaArbitro);
        bool EliminarEscuelaArbitro(string nitEscuelaArbitro);
        EscuelaArbitro BuscarEscuelaArbitro(string nitEscuelaArbitro);
    }
}