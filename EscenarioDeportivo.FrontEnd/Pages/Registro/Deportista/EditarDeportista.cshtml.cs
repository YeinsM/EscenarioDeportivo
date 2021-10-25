using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EscenarioDeportivo.Persistencia;
using EscenarioDeportivo.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace EscenarioDeportivo.FrontEnd.Pages
{
    [Authorize]
    public class EditarDeportistaModel : PageModel
    {
        public readonly IRepositorioDeportista _repoDeportista;
        public readonly IRepositorioEquipo _repoEquipo;
        [BindProperty]
        public Deportista _deportista { get; set; }
        public IEnumerable<Equipo> _listaEquipos { get; set; }
        public List<SelectListItem> _listaGenero { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Masculino", Text = "Masculino" },
            new SelectListItem { Value = "Femenino", Text = "Femenino" }
        };

        public EditarDeportistaModel(IRepositorioDeportista repoDeportista, IRepositorioEquipo repoEquipo)
        {
            this._repoDeportista = repoDeportista;
            this._repoEquipo = repoEquipo;
            _listaEquipos = _repoEquipo.ListarEquipos();
        }
        public ActionResult OnGet(string depDocumento)
        {
            if (depDocumento == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Deportista.";
                return RedirectToPage("./VerDeportistas");
            }

            _deportista = _repoDeportista.BuscarDeportista(depDocumento);

            if (_deportista == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Deportista.";
                return RedirectToPage("./VerDeportistas");
            }
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _actualizado = _repoDeportista.ActualizarDeportista(_deportista);
                if (_actualizado)
                {
                    TempData["mensajeCreado"] = "El deportista " + _deportista.Nombres + " con documento " + _deportista.Documento + " se ha actualizado correctamente!";
                    return RedirectToPage("./VerDeportistas");
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
