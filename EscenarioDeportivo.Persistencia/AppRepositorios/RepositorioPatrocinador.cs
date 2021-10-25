using System;
using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioPatrocinador : IRepositorioPatrocinador
    {
        private readonly AppContext _appContext;

        public RepositorioPatrocinador(AppContext appContext)
        {
            _appContext = appContext;
        }

        bool IRepositorioPatrocinador.CrearPatrocinador(Patrocinador patrocinador)
        {
            bool creado = false;
            bool existe = false;
            try
            {
                existe = ExistePatrocinador(patrocinador);
                if (!existe)
                {
                    _appContext.Patrocinador.Add(patrocinador);
                    _appContext.SaveChanges();
                    creado = true;
                }
            }
            catch (System.Exception)
            {
                //Console.WriteLine("ERROR PATROCINADOR: " + _ex.Message);
                return creado;
            }
            return creado;
        }
        bool IRepositorioPatrocinador.ActualizarPatrocinador(Patrocinador patrocinador)
        {
            bool actualizado = false;
            try
            {
                //var patEncontrado = _appContext.Patrocinador.Find(patrocinador.Id);
                var patEncontrado = _appContext.Patrocinador.FirstOrDefault(d => d.Identificacion == patrocinador.Identificacion);
                if (patEncontrado != null)
                {
                    patEncontrado.Nombre = patrocinador.Nombre;
                    patEncontrado.TipoPersona = patrocinador.TipoPersona;
                    patEncontrado.Direccion = patrocinador.Direccion;
                    patEncontrado.Telefono = patrocinador.Telefono;
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
        bool IRepositorioPatrocinador.EliminarPatrocinador(string identPatrocinador)
        {
            bool eliminado = false;
            try
            {
                var patrocinador = _appContext.Patrocinador.FirstOrDefault(d => d.Identificacion == identPatrocinador);
                var equipo = _appContext.Equipo.FirstOrDefault(e => e.PatrocinadorId ==  patrocinador.Id);
                if (patrocinador != null && equipo == null)
                {
                    _appContext.Patrocinador.Remove(patrocinador);
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
        Patrocinador IRepositorioPatrocinador.BuscarPatrocinador(string identPatrocinador)
        {
            Patrocinador patrocinador = _appContext.Patrocinador.FirstOrDefault(d => d.Identificacion == identPatrocinador);
            return patrocinador;
        }

        IEnumerable<Patrocinador> IRepositorioPatrocinador.ListarPatrocinadores()
        {
            return _appContext.Patrocinador;
        }
        List<Patrocinador> IRepositorioPatrocinador.ListarPatrocinadoresList()
        {
            return _appContext.Patrocinador.ToList();
        }
        List<Equipo> IRepositorioPatrocinador.FiltrarPatrocinadorEquipos(Patrocinador patrocinador)
        {
            return _appContext.Equipo.Where(t => t.PatrocinadorId == patrocinador.Id).ToList();
        }

        bool ExistePatrocinador(Patrocinador _patrocinador)
        {
            bool _existe = false;
            var _mun = _appContext.Patrocinador.FirstOrDefault(i => i.Identificacion == _patrocinador.Identificacion);
            if (_mun != null)
            {
                _existe = true;
            }
            return _existe;
        }
    }
}