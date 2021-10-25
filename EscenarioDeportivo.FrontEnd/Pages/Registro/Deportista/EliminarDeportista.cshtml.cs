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
    public class EliminarDeportistaModel : PageModel
    {
        public readonly IRepositorioDeportista _repoDeportista;
        public readonly IRepositorioEquipo _repoEquipo;
        [BindProperty]
        public Deportista _deportista { get; set; }
        public IEnumerable<Equipo> _listaEquipos { get; set; }

        public EliminarDeportistaModel(IRepositorioDeportista repoDeportista, IRepositorioEquipo repoEquipo)
        {
            this._repoDeportista = repoDeportista;
            this._repoEquipo = repoEquipo;
            _listaEquipos = _repoEquipo.ListarEquipos();
        }
        public ActionResult OnGet(string depDocumento)
        {
            if (depDocumento == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la eliminación del Deportista.";
                return RedirectToPage("./VerDeportistas");
            }

            _deportista = _repoDeportista.BuscarDeportista(depDocumento);

            if (_deportista == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la eliminación del Deportista.";
                return RedirectToPage("./VerDeportistas");
            }
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _eliminado = _repoDeportista.EliminarDeportista(_deportista.Documento);
                if (_eliminado)
                {
                    TempData["mensajeCreado"] = "El deportista " + _deportista.Nombres + " con documento " + _deportista.Documento + " se ha eliminado correctamente!";
                    return RedirectToPage("./VerDeportistas");
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
