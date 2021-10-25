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
    public class CrearMunicipiosModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        [BindProperty]
        public Municipio _municipio { get; set; }

        public CrearMunicipiosModel(IRepositorioMunicipio repoMunicipio)
        {
            this._repoMunicipio = repoMunicipio;
        }
        public ActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _creado = _repoMunicipio.CrearMunicipio(_municipio);
                if (_creado)
                {
                    TempData["mensajeCreado"] = "El municipio " + _municipio.Nombre +" se ha creado correctamente!";
                    return RedirectToPage("./VerMunicipios");
                }
                else
                {
                    ViewData["Mensaje"] = "El municipio ya existe!";
                }
            }
            return Page();
        }
    }
}
