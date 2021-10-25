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
    public class EditarEntrenadorModel : PageModel
    {
        public readonly IRepositorioEntrenador _repoEntrenador;
        [BindProperty]
        public Entrenador _entrenador { get; set; }
        public List<SelectListItem> listaGenero { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Masculino", Text = "Masculino" },
            new SelectListItem { Value = "Femenino", Text = "Femenino" }
        };

        public EditarEntrenadorModel(IRepositorioEntrenador repoEntrenador)
        {
            this._repoEntrenador = repoEntrenador;
        }
        public ActionResult OnGet(string docEntrenador)
        {
            if (docEntrenador == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Entrenador.";
                return RedirectToPage("./VerEntrenadores");
            }

            _entrenador = _repoEntrenador.BuscarEntrenador(docEntrenador);

            if (_entrenador == null)
            {
                TempData["mensajeCreado"] = "Verificar de nuevo la edición del Entrenador.";
                return RedirectToPage("./VerEntrenadores");
            }
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _editado = _repoEntrenador.ActualizarEntrenador(_entrenador);
                if (_editado)
                {
                    TempData["mensajeCreado"] = "El entrenador " + _entrenador.Nombres + " con documento " + _entrenador.Documento + " se actualizó correctamente!";
                    return RedirectToPage("./VerEntrenadores");
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
