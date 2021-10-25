using System;
using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioEscenario:IRepositorioEscenario
    {
        private readonly AppContext _appContext;

        public RepositorioEscenario(AppContext appContext)
        {
            _appContext = appContext;
        }

        bool IRepositorioEscenario.CrearEscenario(Escenario escenario)
        {
            bool creado = false;
            try
            {
                _appContext.Escenario.Add(escenario) ;
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception _ex)
            {
                Console.WriteLine("ERROR ESCENARIO: " + _ex.Message);
                return creado;
            }
            return creado;
        }
        bool IRepositorioEscenario.ActualizarEscenario(Escenario escenario)
        {
            bool actualizado = false;
            try
            {
                 var munEncontrado = _appContext.Escenario.Find(escenario.Id);
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
        bool IRepositorioEscenario.EliminarEscenario(int id)
        {
            bool eliminado = false;
            try
            {
                 var escenario = _appContext.Escenario.FirstOrDefault(d => d.Id == id);
                 if(escenario != null)
                 {
                     _appContext.Escenario.Remove(escenario);
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
        Escenario IRepositorioEscenario.BuscarEscenario(int id)
        {
            Escenario escenario = _appContext.Escenario.FirstOrDefault(d => d.Id == id);
            return escenario;
        }

        IEnumerable<Escenario> IRepositorioEscenario.ListarEscenarios()
        {
            return _appContext.Escenario;
        }
    }
}