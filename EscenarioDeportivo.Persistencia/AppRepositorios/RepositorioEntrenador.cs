using System;
using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioEntrenador : IRepositorioEntrenador
    {
        private readonly AppContext _appContext;

        public RepositorioEntrenador(AppContext appContext)
        {
            _appContext = appContext;
        }

        bool IRepositorioEntrenador.CrearEntrenador(Entrenador entrenador)
        {
            bool creado = false;
            bool existe = false;
            try
            {
                existe = ExisteEntrenador(entrenador);
                if (!existe)
                {
                    _appContext.Entrenador.Add(entrenador);
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
        bool IRepositorioEntrenador.ActualizarEntrenador(Entrenador entrenador)
        {
            bool actualizado = false;
            try
            {
                var entEncontrado = _appContext.Entrenador.FirstOrDefault(d => d.Documento == entrenador.Documento);
                if (entEncontrado != null)
                {
                    entEncontrado.Nombres = entrenador.Nombres;
                    entEncontrado.Apellidos = entrenador.Apellidos;
                    entEncontrado.Genero = entrenador.Genero;
                    entEncontrado.DisciplinaDeportiva = entrenador.DisciplinaDeportiva;
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
        bool IRepositorioEntrenador.EliminarEntrenador(string docEntrenador)
        {
            bool eliminado = false;
            try
            {
                var entrenador = _appContext.Entrenador.FirstOrDefault(d => d.Documento == docEntrenador);
                if (entrenador != null)
                {
                    _appContext.Entrenador.Remove(entrenador);
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
        Entrenador IRepositorioEntrenador.BuscarEntrenador(string docEntrenador)
        {
            Entrenador entrenador = _appContext.Entrenador.FirstOrDefault(d => d.Documento == docEntrenador);
            return entrenador;
        }

        IEnumerable<Entrenador> IRepositorioEntrenador.ListarEntrenadores()
        {
            return _appContext.Entrenador;
        }
        bool ExisteEntrenador(Entrenador _entrenador)
        {
            bool _existe = false;
            var _ent = _appContext.Entrenador.FirstOrDefault(e => e.Documento == _entrenador.Documento);
            if (_ent != null)
            {
                _existe = true;
            }
            return _existe;
        }
    }
}