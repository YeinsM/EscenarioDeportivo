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
    public class CancelarInscripcionModel : PageModel
    {
        public readonly IRepositorioTorneoEquipo _repoTorneoEquipo;
        [BindProperty]
        public TorneoEquipo _torneoEquipo { get; set; }

        public CancelarInscripcionModel(IRepositorioTorneoEquipo repoTorneoEquipo)
        {
            this._repoTorneoEquipo = repoTorneoEquipo;
        }
        public ActionResult OnGet(int ETorneoId, int EEquipoId, String TNombre, String ENombre)
        {
            _torneoEquipo = _repoTorneoEquipo.BuscarTorneoEquipoId(ETorneoId,EEquipoId);
            
            bool eliminado = _repoTorneoEquipo.EliminarTorneoEquipo(_torneoEquipo);
            if (eliminado)
            {
                TempData["mensajeCreado"] = "El equipo " + ENombre + " se eliminó del torneo " + TNombre;
            }
            else
            {
                TempData["mensajeCreado"] = "Se presentó un error al eliminar.";
            }
            return RedirectToPage("../Inscripcion/InscripcionTorneo");
        }
    }
}
