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
    public class CrearTorneoModel : PageModel
    {
        public readonly IRepositorioTorneo _repoTorneo;
        public readonly IRepositorioMunicipio _repoMunicipio;
        [BindProperty]
        public Torneo _torneo { get; set; }
        public IEnumerable<Municipio> _listaMunicipios { get; set; }

        public CrearTorneoModel(IRepositorioTorneo repoTorneo, IRepositorioMunicipio repoMunicipio)
        {
            this._repoTorneo = repoTorneo;
            this._repoMunicipio = repoMunicipio;
            _listaMunicipios = _repoMunicipio.ListarMunicipios();
        }
        public ActionResult OnGet()
        {
            if (_listaMunicipios != null && _listaMunicipios.Count() > 0)
            {
                return Page();
            }
            else
            {
                TempData["mensajeCreado"] = "Para crear un Torneo debe crear primero Municipios.";
                return RedirectToPage("./VerTorneos");
            }
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _creado = _repoTorneo.CrearTorneo(_torneo);
                if (_creado)
                {
                    TempData["mensajeCreado"] = "El torneo " + _torneo.Nombre + " se ha creado correctamente!";
                    return RedirectToPage("./VerTorneos");
                }
                else
                {
                    ViewData["Mensaje"] = "El torneo " + _torneo.Nombre + " ya existe!";
                }
            }
            return Page();
        }
    }
}
