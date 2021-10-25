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
    public class EditarTorneoModel : PageModel
    {
        public readonly IRepositorioTorneo _repoTorneo;
        public readonly IRepositorioMunicipio _repoMunicipio;
        [BindProperty]
        public Torneo _torneo { get; set; }
        public IEnumerable<Municipio> _listaMunicipios { get; set; }

        public EditarTorneoModel(IRepositorioTorneo repoTorneo, IRepositorioMunicipio repoMunicipio)
        {
            this._repoTorneo = repoTorneo;
            this._repoMunicipio = repoMunicipio;
            _listaMunicipios = _repoMunicipio.ListarMunicipios();
        }
        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Torneo.";
                return RedirectToPage("./VerTorneos");
            }

            _torneo = _repoTorneo.BuscarTorneoId(id);

            if (_torneo == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Torneo.";
                return RedirectToPage("./VerTorneos");
            }
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _actualizado = _repoTorneo.ActualizarTorneo(_torneo);
                if (_actualizado)
                {
                    TempData["mensajeCreado"] = "El torneo " + _torneo.Nombre + " se actualizó correctamente!";
                    return RedirectToPage("./VerTorneos");
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
