using System;
using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioEscuelaArbitro:IRepositorioEscuelaArbitro
    {
        private readonly AppContext _appContext;

        public RepositorioEscuelaArbitro(AppContext appContext)
        {
            _appContext = appContext;
        }

        bool IRepositorioEscuelaArbitro.CrearEscuelaArbitro(EscuelaArbitro escuelaArbitro)
        {
            bool creado = false;
            try
            {
                _appContext.Escuela.Add(escuelaArbitro) ;
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception _ex)
            {
                Console.WriteLine("ERROR ESCUELAARBITRO: " + _ex.Message);
                return creado;
            }
            return creado;
        }
        bool IRepositorioEscuelaArbitro.ActualizarEscuelaArbitro(EscuelaArbitro escuelaArbitro)
        {
            bool actualizado = false;
            try
            {
                 var munEncontrado = _appContext.Escuela.Find(escuelaArbitro.Id);
                 if(munEncontrado != null)
                 {
                     //munEncontrado.Nombre = municipio.Nombre;
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
        bool IRepositorioEscuelaArbitro.EliminarEscuelaArbitro(string nitEscuelaArbitro)
        {
            bool eliminado = false;
            try
            {
                 var escuelaArbitro = _appContext.Escuela.FirstOrDefault(d => d.Nit == nitEscuelaArbitro);
                 if(escuelaArbitro != null)
                 {
                     _appContext.Escuela.Remove(escuelaArbitro);
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
        EscuelaArbitro IRepositorioEscuelaArbitro.BuscarEscuelaArbitro(string nitEscuelaArbitro)
        {
            EscuelaArbitro escuelaArbitro = _appContext.Escuela.FirstOrDefault(d => d.Nit == nitEscuelaArbitro);
            return escuelaArbitro;
        }

        IEnumerable<EscuelaArbitro> IRepositorioEscuelaArbitro.ListarEscuelaArbitros()
        {
            return _appContext.Escuela;
        }
    }
}