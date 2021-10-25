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
    public class EliminarTorneoModel : PageModel
    {
        public readonly IRepositorioTorneo _repoTorneo;
        public readonly IRepositorioMunicipio _repoMunicipio;
        [BindProperty]
        public Torneo _torneo { get; set; }
        public IEnumerable<Municipio> _listaMunicipios { get; set; }

        public EliminarTorneoModel(IRepositorioTorneo repoTorneo, IRepositorioMunicipio repoMunicipio)
        {
            this._repoTorneo = repoTorneo;
            this._repoMunicipio = repoMunicipio;
            _listaMunicipios = _repoMunicipio.ListarMunicipios();
        }
        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la eliminación del Torneo.";
                return RedirectToPage("./VerTorneos");
            }

            _torneo = _repoTorneo.BuscarTorneoId(id);

            if (_torneo == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la eliminación del Torneo.";
                return RedirectToPage("./VerTorneos");
            }

            _torneo.TorneoEquipos = _repoTorneo.FiltrarInscripcionesTorneo(_torneo);
            if (_torneo.TorneoEquipos.Count() > 0)
            {
                TempData["mensajeCreado"] = "El torneo " + _torneo.Nombre + " tiene " + _torneo.TorneoEquipos.Count().ToString() + " equipos inscritos. No se puede eliminar.";
                return RedirectToPage("./VerTorneos");
            }
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _eliminado = _repoTorneo.EliminarTorneo(_torneo.Id);
                if (_eliminado)
                {
                    TempData["mensajeCreado"] = "El torneo " + _torneo.Nombre + " se eliminó correctamente!";
                    return RedirectToPage("./VerTorneos");
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
