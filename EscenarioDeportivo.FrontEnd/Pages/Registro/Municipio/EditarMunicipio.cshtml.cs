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
    public class EditarMunicipioModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        [BindProperty]
        public Municipio _municipio { get; set; }

        public EditarMunicipioModel(IRepositorioMunicipio repoMunicipio)
        {
            this._repoMunicipio = repoMunicipio;
        }
        public ActionResult OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                //return NotFound();
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Municipio.";
                return RedirectToPage("./VerMunicipios");
            }

            _municipio = _repoMunicipio.BuscarMunicipio(id);

            if (_municipio == null)
            {
                //return NotFound();
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Municipio.";
                return RedirectToPage("./VerMunicipios");
            }
            TempData["mensajeCreado"] = "El municipio " + _municipio.Nombre;
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _actualizado = _repoMunicipio.ActualizarMunicipio(_municipio);
                if (_actualizado)
                {
                    TempData["mensajeCreado"] = TempData["mensajeCreado"] + " se actualizó por " + _municipio.Nombre + " correctamente!";
                    return RedirectToPage("./VerMunicipios");
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
