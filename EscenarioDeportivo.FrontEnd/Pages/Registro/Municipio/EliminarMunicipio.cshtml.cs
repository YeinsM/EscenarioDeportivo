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
    public class EliminarMunicipioModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        [BindProperty]
        public Municipio _municipio { get; set; }

        public EliminarMunicipioModel(IRepositorioMunicipio repoMunicipio)
        {
            this._repoMunicipio = repoMunicipio;
        }
        public ActionResult OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                //return NotFound();
                TempData["mensajeCreado"] = "Verificar de nuevo la eliminación del Municipio.";
                return RedirectToPage("./VerMunicipios");
            }

            _municipio = _repoMunicipio.BuscarMunicipio(id);

            if (_municipio == null)
            {
                //return NotFound();
                TempData["mensajeCreado"] = "Verificar de nuevo la eliminación del Municipio.";
                return RedirectToPage("./VerMunicipios");
            }

            _municipio.Torneos = _repoMunicipio.FiltrarMunicipiosTorneos(_municipio);
            if (_municipio.Torneos.Count() > 0)
            {
                TempData["mensajeCreado"] = "El municipio está asignado a " + _municipio.Torneos.Count().ToString() + " torneos. No se puede eliminar.";
                return RedirectToPage("./VerMunicipios");
            }
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _actualizado = _repoMunicipio.EliminarMunicipio(_municipio.Id);
                if (_actualizado)
                {
                    TempData["mensajeCreado"] = "El municipio " + _municipio.Nombre + " se eliminó correctamente!";
                    return RedirectToPage("./VerMunicipios");
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
