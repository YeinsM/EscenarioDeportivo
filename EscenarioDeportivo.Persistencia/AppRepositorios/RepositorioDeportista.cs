using System;
using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioDeportista : IRepositorioDeportista
    {
        private readonly AppContext _appContext;

        public RepositorioDeportista(AppContext appContext)
        {
            _appContext = appContext;
        }

        bool IRepositorioDeportista.CrearDeportista(Deportista deportista)
        {
            bool creado = false;
            bool existe = false;
            try
            {
                existe = ExisteDeportista(deportista);
                if (!existe)
                {
                    _appContext.Deportista.Add(deportista);
                    _appContext.SaveChanges();
                    creado = true;
                }
            }
            catch (System.Exception _ex)
            {
                Console.WriteLine("ERROR DEPORTISTA: " + _ex.Message);
                return creado;
            }
            return creado;
        }
        bool IRepositorioDeportista.ActualizarDeportista(Deportista deportista)
        {
            bool actualizado = false;
            try
            {
                var depEncontrado = _appContext.Deportista.FirstOrDefault(d => d.Documento == deportista.Documento);
                if (depEncontrado != null)
                {
                    depEncontrado.Documento = deportista.Documento;
                    depEncontrado.Nombres = deportista.Nombres;
                    depEncontrado.Apellidos = deportista.Apellidos;
                    depEncontrado.Genero = deportista.Genero;
                    depEncontrado.Rh = deportista.Rh;
                    depEncontrado.EPS = deportista.EPS;
                    depEncontrado.FechaNacimiento = deportista.FechaNacimiento;
                    depEncontrado.Disciplina = deportista.Disciplina;
                    depEncontrado.Direccion = deportista.Direccion;
                    depEncontrado.EquipoId = deportista.EquipoId;
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
        bool IRepositorioDeportista.EliminarDeportista(string docDeportista)
        {
            bool eliminado = false;
            try
            {
                var deportista = _appContext.Deportista.FirstOrDefault(d => d.Documento == docDeportista);
                if (deportista != null)
                {
                    _appContext.Deportista.Remove(deportista);
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
        Deportista IRepositorioDeportista.BuscarDeportista(string docDeportista)
        {
            Deportista deportista = _appContext.Deportista.FirstOrDefault(d => d.Documento == docDeportista);
            return deportista;
        }

        IEnumerable<Deportista> IRepositorioDeportista.ListarDeportistas()
        {
            return _appContext.Deportista;
        }
        bool ExisteDeportista(Deportista _deportista)
        {
            bool _existe = false;
            var _dep = _appContext.Deportista.FirstOrDefault(d => d.Documento == _deportista.Documento);
            if (_dep != null)
            {
                _existe = true;
            }
            return _existe;
        }
    }
}