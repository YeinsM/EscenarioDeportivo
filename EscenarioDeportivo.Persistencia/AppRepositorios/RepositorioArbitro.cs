using System;
using System.Collections.Generic;
using EscenarioDeportivo.Dominio;
using System.Linq;

namespace EscenarioDeportivo.Persistencia
{
    public class RepositorioArbitro:IRepositorioArbitro
    {
        private readonly AppContext _appContext;

        public RepositorioArbitro(AppContext appContext)
        {
            _appContext = appContext;
        }
        bool IRepositorioArbitro.CrearArbitro(Arbitro arbitro)
        {
            bool creado = false;
            try
            {
                _appContext.Arbitro.Add(arbitro) ;
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception _ex)
            {
                Console.WriteLine("ERROR ARBITRO: " + _ex.Message);
                return creado;
            }
            return creado;
        }
        bool IRepositorioArbitro.ActualizarArbitro(Arbitro arbitro)
        {
            bool actualizado = false;
            try
            {
                 //var munEncontrado = _appContext.Arbitro.Find(arbitro.Id);
                 var arbEncontrado = _appContext.Arbitro.FirstOrDefault(a => a.Documento == arbitro.Documento);
                 if(arbEncontrado != null)
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
        bool IRepositorioArbitro.EliminarArbitro(string docArbitro)
        {
            bool eliminado = false;
            try
            {
                 var arbitro = _appContext.Arbitro.FirstOrDefault(d => d.Documento == docArbitro);
                 if(arbitro != null)
                 {
                     _appContext.Arbitro.Remove(arbitro);
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
        Arbitro IRepositorioArbitro.BuscarArbitro(string docArbitro)
        {
            Arbitro arbitro = _appContext.Arbitro.FirstOrDefault(d => d.Documento == docArbitro);
            return arbitro;
        }

        IEnumerable<Arbitro> IRepositorioArbitro.ListarArbitros()
        {
            return _appContext.Arbitro;
        }
    }
}