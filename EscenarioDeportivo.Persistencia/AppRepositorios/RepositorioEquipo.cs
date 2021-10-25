using System;
using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private readonly AppContext _appContext;

        public RepositorioEquipo(AppContext appContext)
        {
            _appContext = appContext;
        }

        bool IRepositorioEquipo.CrearEquipo(Equipo equipo)
        {
            bool creado = false;
            bool existe = false;
            try
            {
                existe = ExisteEquipo(equipo);
                if (!existe)
                {
                    _appContext.Equipo.Add(equipo);
                    _appContext.SaveChanges();
                    creado = true;
                }
            }
            catch (System.Exception _ex)
            {
                Console.WriteLine("ERROR EQUIPO: " + _ex.Message);
                return creado;
            }
            return creado;
        }
        bool IRepositorioEquipo.ActualizarEquipo(Equipo equipo)
        {
            bool actualizado = false;
            try
            {
                var equEncontrado = _appContext.Equipo.Find(equipo.Id);
                if (equEncontrado != null)
                {
                    equEncontrado.Nombre = equipo.Nombre;
                    equEncontrado.CantidadDeportistas = equipo.CantidadDeportistas;
                    equEncontrado.Disciplina = equipo.Disciplina;
                    equEncontrado.PatrocinadorId = equipo.PatrocinadorId;
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
        bool IRepositorioEquipo.EliminarEquipo(int id)
        {
            bool eliminado = false;
            try
            {
                var equipo = _appContext.Equipo.FirstOrDefault(d => d.Id == id);
                if (equipo != null)
                {
                    _appContext.Equipo.Remove(equipo);
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
        Equipo IRepositorioEquipo.BuscarEquipo(Equipo _equipo)
        {
            Equipo equipo = _appContext.Equipo.FirstOrDefault(e => e.Nombre.ToUpper() == _equipo.Nombre.ToUpper());
            return equipo;
        }
        Equipo IRepositorioEquipo.BuscarEquipoId(int? id)
        {
            Equipo equipo = _appContext.Equipo.FirstOrDefault(e => e.Id == id);
            return equipo;
        }
        IEnumerable<Equipo> IRepositorioEquipo.ListarEquipos()
        {
            return _appContext.Equipo;
        }
        List<Equipo> IRepositorioEquipo.ListarEquiposList()
        {
            return _appContext.Equipo.ToList();
        }
        bool ExisteEquipo(Equipo _equipo)
        {
            bool _existe = false;
            var _equ = _appContext.Equipo.FirstOrDefault(e => e.Nombre.ToUpper() == _equipo.Nombre.ToUpper());
            if (_equ != null)
            {
                _existe = true;
            }
            return _existe;
        }
        List<Deportista> IRepositorioEquipo.FiltrarDeportistasEquipo(Equipo equipo)
        {
            return _appContext.Deportista.Where(d => d.EquipoId == equipo.Id).ToList();
        }
        List<TorneoEquipo> IRepositorioEquipo.FiltrarinscripcionEquipos(Equipo equipo)
        {
            return _appContext.TorneoEquipo.Where(t => t.EquipoId == equipo.Id).ToList();
        }
    }
}