using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EscenarioDeportivo.Persistencia;
using EscenarioDeportivo.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace EscenarioDeportivo.FrontEnd.Pages
{
    [Authorize]
    public class EliminarEquipoModel : PageModel
    {
        public readonly IRepositorioEquipo _repoEquipo;
        public readonly IRepositorioPatrocinador _repoPatrocinador;
        [BindProperty]
        public Equipo _equipo { get; set; }
        public IEnumerable<Patrocinador> _listaPatrocinadores { get; set; }
        public EliminarEquipoModel(IRepositorioEquipo repoEquipo, IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoEquipo = repoEquipo;
            this._repoPatrocinador = repoPatrocinador;
        }
        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la eliminación del Equipo.";
                return RedirectToPage("./VerEquipos");
            }

            _equipo = _repoEquipo.BuscarEquipoId(id);

            if (_equipo == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la eliminación del Equipo.";
                return RedirectToPage("./VerEquipos");
            }

            _equipo.TorneoEquipos = _repoEquipo.FiltrarinscripcionEquipos(_equipo);
            if (_equipo.TorneoEquipos.Count() > 0)
            {
                TempData["mensajeCreado"] = "El equipo " + _equipo.Nombre + " tiene " + _equipo.TorneoEquipos.Count().ToString() + " incripciones en Torneos. No se puede eliminar.";
                return RedirectToPage("./VerEquipos");
            }
            _equipo.Deportistas = _repoEquipo.FiltrarDeportistasEquipo(_equipo);
            if (_equipo.Deportistas.Count() > 0)
            {
                ViewData["Mensaje"] = "NOTA: El equipo " + _equipo.Nombre + " tiene " + _equipo.Deportistas.Count().ToString() + " deportistas. También se Eliminarán";
            }
            _listaPatrocinadores = _repoPatrocinador.ListarPatrocinadores();
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _eliminado = _repoEquipo.EliminarEquipo(_equipo.Id);
                if (_eliminado)
                {
                    TempData["mensajeCreado"] = "El equipo " + _equipo.Nombre + " se eliminó correctamente!";
                    return RedirectToPage("./VerEquipos");
                }
                else
                {
                    TempData.Remove("mensajeCreado");
                    ViewData["Mensaje"] = "Se presenta un error al eliminar.";
                    return Page();
                }
            }
            return Page();
        }
    }
}
