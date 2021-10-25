using System.Collections.Generic;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public interface IRepositorioDeportista
    {
        IEnumerable<Deportista> ListarDeportistas();
        bool CrearDeportista(Deportista deportista);
        bool ActualizarDeportista(Deportista deportista);
        bool EliminarDeportista(string docDeportista);
        Deportista BuscarDeportista(string docDeportista);
    }
}