using System.Collections.Generic;
using EscenarioDeportivo.Dominio;

namespace EscenarioDeportivo.Persistencia
{
    public interface IRepositorioMunicipio
    {
        IEnumerable<Municipio> ListarMunicipios();
        List<Municipio> ListarMunicipiosList();
        List<Torneo> FiltrarMunicipiosTorneos(Municipio municipio);
        bool CrearMunicipio(Municipio municipio);
        bool ActualizarMunicipio(Municipio municipio);
        bool EliminarMunicipio(int idMunicipio);
        Municipio BuscarMunicipio(int? idMunicipio);
    }
}