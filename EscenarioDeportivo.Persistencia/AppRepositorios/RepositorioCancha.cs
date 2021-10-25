using System;
using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioCancha:IRepositorioCancha
    {
        private readonly AppContext _appContext;
        public RepositorioCancha(AppContext appContext)
        {
            _appContext = appContext;
        }
        bool IRepositorioCancha.CrearCancha(Cancha cancha)
        {
            bool creado = false;
            try
            {
                _appContext.Cancha.Add(cancha) ;
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception _ex)
            {
                Console.WriteLine("ERROR CANCHA: " + _ex.Message);
                return creado;
            }
            return creado;
        }
        bool IRepositorioCancha.ActualizarCancha(Cancha cancha)
        {
            bool actualizado = false;
            try
            {
                 var canEncontrado = _appContext.Cancha.Find(cancha.Id);
                 if(canEncontrado != null)
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
        bool IRepositorioCancha.EliminarCancha(int idCancha)
        {
            bool eliminado = false;
            try
            {
                 var cancha = _appContext.Cancha.FirstOrDefault(d => d.Id == idCancha);
                 if(cancha != null)
                 {
                     _appContext.Cancha.Remove(cancha);
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
        Cancha IRepositorioCancha.BuscarCancha(int idCancha)
        {
            Cancha cancha = _appContext.Cancha.FirstOrDefault(d => d.Id == idCancha);
            return cancha;
        }

        IEnumerable<Cancha> IRepositorioCancha.ListarCanchas()
        {
            return _appContext.Cancha;
        }
    }
}