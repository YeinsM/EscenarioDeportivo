using System.Collections.Generic;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public interface IRepositorioArbitro
    {
        IEnumerable<Arbitro> ListarArbitros();
        bool CrearArbitro(Arbitro arbitro);
        bool ActualizarArbitro(Arbitro arbitro);
        bool EliminarArbitro(string docArbitro);
        Arbitro BuscarArbitro(string docArbitro);
    }
}