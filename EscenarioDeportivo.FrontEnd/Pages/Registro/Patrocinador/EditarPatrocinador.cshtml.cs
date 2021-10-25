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
    public class EditarPatrocinadorModel : PageModel
    {
        private readonly IRepositorioPatrocinador _repoPatrocinador;
        [BindProperty]
        public Patrocinador _patrocinador { get; set; }
        public List<SelectListItem> listaTipo { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Natural", Text = "Natural" },
            new SelectListItem { Value = "Juridico", Text = "Juridico" }
        };

        public EditarPatrocinadorModel(IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador = repoPatrocinador;
        }
        public ActionResult OnGet(string identPatrocinador)
        {
            if (identPatrocinador == null)
            {
                //return NotFound();
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Patrocinador.";
                return RedirectToPage("./VerPatrocinadores");
            }

            _patrocinador = _repoPatrocinador.BuscarPatrocinador(identPatrocinador);

            if (_patrocinador == null)
            {
                //return NotFound();
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Patrocinador.";
                return RedirectToPage("./VerPatrocinadores");
            }
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _editado = _repoPatrocinador.ActualizarPatrocinador(_patrocinador);
                if (_editado)
                {
                    TempData["mensajeCreado"] = "El patrocinador " + _patrocinador.Nombre + " identificado " + _patrocinador.Identificacion + " se actualizó correctamente!";
                    return RedirectToPage("./VerPatrocinadores");
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
