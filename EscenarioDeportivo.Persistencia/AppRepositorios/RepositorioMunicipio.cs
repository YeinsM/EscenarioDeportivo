using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        private readonly AppContext _appContext;

        public RepositorioMunicipio(AppContext appContext)
        {
            _appContext = appContext;
        }

        bool IRepositorioMunicipio.CrearMunicipio(Municipio municipio)
        {
            bool creado = false;
            bool existe = false;
            try
            {
                existe = ExisteMunicipio(municipio);
                if (!existe)
                {
                    _appContext.Municipio.Add(municipio);
                    _appContext.SaveChanges();
                    creado = true;
                }
            }
            catch (System.Exception)
            {
                return creado;
            }
            return creado;
        }
        bool IRepositorioMunicipio.ActualizarMunicipio(Municipio municipio)
        {
            bool actualizado = false;
            try
            {
                var munEncontrado = _appContext.Municipio.Find(municipio.Id);
                if (munEncontrado != null)
                {
                    munEncontrado.Nombre = municipio.Nombre;
                    _appContext.SaveChanges();
                    actualizado = true;
                }
            }
            catch (System.Exception)
            {
                return actualizado;
            }
            return actualizado;
        }
        bool IRepositorioMunicipio.EliminarMunicipio(int idMunicipio)
        {
            bool eliminado = false;
            try
            {
                var municipio = _appContext.Municipio.Find(idMunicipio);
                if (municipio != null)
                {
                    _appContext.Municipio.Remove(municipio);
                    _appContext.SaveChanges();
                    eliminado = true;
                }
            }
            catch (System.Exception)
            {
                return eliminado;
            }
            return eliminado;
        }
        Municipio IRepositorioMunicipio.BuscarMunicipio(int? idMunicipio)
        {
            Municipio municipio = _appContext.Municipio.Find(idMunicipio);
            return municipio;
        }

        IEnumerable<Municipio> IRepositorioMunicipio.ListarMunicipios()
        {
            return _appContext.Municipio;
        }
        List<Municipio> IRepositorioMunicipio.ListarMunicipiosList()
        {
            return _appContext.Municipio.ToList();
        }

        bool ExisteMunicipio(Municipio _municipio)
        {
            bool _existe = false;
            var _mun = _appContext.Municipio.FirstOrDefault(m => m.Nombre == _municipio.Nombre);
            if (_mun != null)
            {
                _existe = true;
            }
            return _existe;
        }
        List<Torneo> IRepositorioMunicipio.FiltrarMunicipiosTorneos(Municipio municipio)
        {
            return _appContext.Torneo.Where(t => t.MunicipioId == municipio.Id).ToList();
        }
    }
}