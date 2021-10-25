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
    public class EditarEquipoModel : PageModel
    {
        public readonly IRepositorioEquipo _repoEquipo;
        public readonly IRepositorioPatrocinador _repoPatrocinador;
        [BindProperty]
        public Equipo _equipo { get; set; }
        public IEnumerable<Patrocinador> _listaPatrocinadores { get; set; }
        
        public EditarEquipoModel(IRepositorioEquipo repoEquipo, IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoEquipo = repoEquipo;
            this._repoPatrocinador = repoPatrocinador;
            _listaPatrocinadores = _repoPatrocinador.ListarPatrocinadores();
        }
        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Equipo.";
                return RedirectToPage("./VerEquipos");
            }

            _equipo = _repoEquipo.BuscarEquipoId(id);

            if (_equipo == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Equipo.";
                return RedirectToPage("./VerEquipos");
            }
            //_listaPatrocinadores = _repoPatrocinador.ListarPatrocinadores();
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _actualizado = _repoEquipo.ActualizarEquipo(_equipo);
                if (_actualizado)
                {
                    TempData["mensajeCreado"] = "El equipo " + _equipo.Nombre + " se actualizó correctamente!";
                    return RedirectToPage("./VerEquipos");
                }
                else
                {
                    TempData.Remove("mensajeCreado");
                    ViewData["Mensaje"] = "Se presenta un error al actualizar.";
                    return Page();
                }
            }
            return Page();
        }
    }
}
