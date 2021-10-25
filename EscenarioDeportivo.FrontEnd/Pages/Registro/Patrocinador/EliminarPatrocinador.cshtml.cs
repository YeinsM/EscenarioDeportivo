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
    public class EliminarPatrocinadorModel : PageModel
    {
        private readonly IRepositorioPatrocinador _repoPatrocinador;
        [BindProperty]
        public Patrocinador _patrocinador { get; set; }

        public EliminarPatrocinadorModel(IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador = repoPatrocinador;
        }
        public ActionResult OnGet(string identPatrocinador)
        {
            if (identPatrocinador == null)
            {
                //return NotFound();
                TempData["mensajeCreado"] = "Verificar de nuevo la eliminación del Patrocinador.";
                return RedirectToPage("./VerPatrocinadores");
            }

            _patrocinador = _repoPatrocinador.BuscarPatrocinador(identPatrocinador);

            if (_patrocinador == null)
            {
                //return NotFound();
                TempData["mensajeCreado"] = "Verificar de nuevo la eliminación del Patrocinador.";
                return RedirectToPage("./VerPatrocinadores");
            }

            _patrocinador.Equipos = _repoPatrocinador.FiltrarPatrocinadorEquipos(_patrocinador);
            if (_patrocinador.Equipos.Count() > 0)
            {
                TempData["mensajeCreado"] = "El patrocinador está asignado a " + _patrocinador.Equipos.Count().ToString() + " equipos. No se puede eliminar.";
                return RedirectToPage("./VerPatrocinadores");
            }
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _creado = _repoPatrocinador.EliminarPatrocinador(_patrocinador.Identificacion);
                if (_creado)
                {
                    TempData["mensajeCreado"] = "El patrocinador " + _patrocinador.Nombre + " se eliminó correctamente!";
                    return RedirectToPage("./VerPatrocinadores");
                }
                else
                {
                    TempData.Remove("mensajeCreado");
                    ViewData["Mensaje"] = "Verificar si el Patrocinador " + _patrocinador.Nombre + " tiene equipos asignados.";
                    return Page();
                }
            }
            return Page();
        }
    }
}
