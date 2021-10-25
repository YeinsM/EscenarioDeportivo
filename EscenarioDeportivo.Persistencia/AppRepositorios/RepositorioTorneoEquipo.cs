using System;
using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioTorneoEquipo : IRepositorioTorneoEquipo
    {
        private readonly AppContext _appContext;

        public RepositorioTorneoEquipo(AppContext appContext)
        {
            _appContext = appContext;
        }

        bool IRepositorioTorneoEquipo.CrearTorneoEquipo(TorneoEquipo torneoEquipo)
        {
            bool creado = false;
            bool existe = false;
            try
            {
                 existe = ExisteTorneoEquipo(torneoEquipo);
                 if (!existe)
                 {
                     _appContext.TorneoEquipo.Add(torneoEquipo);
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
        bool IRepositorioTorneoEquipo.EliminarTorneoEquipo(TorneoEquipo torneoEquipo)
        {
            bool eliminado = false;
            try
            {
                 var encTorneoEquipo = _appContext.TorneoEquipo.FirstOrDefault(te => te.EquipoId == torneoEquipo.EquipoId && te.TorneoId == torneoEquipo.TorneoId);
                 if (encTorneoEquipo != null)
                 {
                     _appContext.TorneoEquipo.Remove(encTorneoEquipo);
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
        TorneoEquipo IRepositorioTorneoEquipo.BuscarTorneoEquipoId(int ETorneoId,int EEquipoId)
        {
            TorneoEquipo torneoEquipo = _appContext.TorneoEquipo.Find(ETorneoId,EEquipoId);
            return torneoEquipo;
        }
        IEnumerable<TorneoEquipo> IRepositorioTorneoEquipo.ListarTorneosEquipos()
        {
            return _appContext.TorneoEquipo;
        }
        bool ExisteTorneoEquipo(TorneoEquipo _torneoEquipo)
        {
            bool _existe = false;
            var _tor = _appContext.TorneoEquipo.FirstOrDefault(te => te.EquipoId == _torneoEquipo.EquipoId && te.TorneoId == _torneoEquipo.TorneoId);
            if (_tor != null)
            {
                _existe = true;
            }
            return _existe;
        }
    }
}