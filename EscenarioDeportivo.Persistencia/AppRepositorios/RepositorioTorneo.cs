using System;
using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioTorneo : IRepositorioTorneo
    {
        private readonly AppContext _appContext;
        public RepositorioTorneo(AppContext appContext)
        {
            _appContext = appContext;
        }

        bool IRepositorioTorneo.CrearTorneo(Torneo torneo)
        {
            bool creado = false;
            bool existe = false;
            try
            {
                existe = ExisteTorneo(torneo);
                if (!existe)
                {
                    _appContext.Torneo.Add(torneo);
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
        bool IRepositorioTorneo.ActualizarTorneo(Torneo torneo)
        {
            bool actualizado = false;
            try
            {
                 var torEncontrado = _appContext.Torneo.Find(torneo.Id);
                 if (torEncontrado != null)
                 {
                     torEncontrado.Nombre = torneo.Nombre;
                     torEncontrado.Categoria = torneo.Categoria;
                     torEncontrado.FechaInicial = torneo.FechaInicial;
                     torEncontrado.FechaFinal = torneo.FechaFinal;
                     torEncontrado.Tipo = torneo.Tipo;
                     torEncontrado.MunicipioId = torneo.MunicipioId;
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
        bool IRepositorioTorneo.EliminarTorneo(int id)
        {
            bool eliminado = false;
            try
            {
                 var torneo = _appContext.Torneo.FirstOrDefault(t => t.Id == id);
                 if (torneo != null)
                 {
                     _appContext.Torneo.Remove(torneo);
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
        Torneo IRepositorioTorneo.BuscarTorneoId(int? id)
        {
            Torneo torneo = _appContext.Torneo.Find(id);
            return torneo;
        }
        Torneo IRepositorioTorneo.BuscarTorneo(Torneo _torneo)
        {
            Torneo torneo = _appContext.Torneo.FirstOrDefault(t => t.Nombre.ToUpper() == _torneo.Nombre.ToUpper());
            return torneo;
        }
        IEnumerable<Torneo> IRepositorioTorneo.ListarTorneos()
        {
            return _appContext.Torneo;
        }
        List<Torneo> IRepositorioTorneo.ListarTorneosList()
        {
            return _appContext.Torneo.ToList();
        }
        bool ExisteTorneo(Torneo _torneo)
        {
            bool _existe = false;
            //var _tor = _appContext.Torneo.FirstOrDefault(t => t.Id == _torneo.Id);
            var _tor = _appContext.Torneo.FirstOrDefault(t => t.Nombre.ToUpper() == _torneo.Nombre.ToUpper());
            if (_tor != null)
            {
                _existe = true;
            }
            return _existe;
        }
        List<TorneoEquipo> IRepositorioTorneo.FiltrarInscripcionesTorneo(Torneo torneo)
        {
            return _appContext.TorneoEquipo.Where(te => te.TorneoId == torneo.Id).ToList();
        }
    }
}