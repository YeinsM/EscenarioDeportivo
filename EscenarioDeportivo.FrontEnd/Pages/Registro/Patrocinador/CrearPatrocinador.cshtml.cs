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
    public class CrearPatrocinadorModel : PageModel
    {
        private readonly IRepositorioPatrocinador _repoPatrocinador;
        [BindProperty]
        public Patrocinador _patrocinador { get; set; }

        public List<SelectListItem> listaTipo { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Natural", Text = "Natural" },
            new SelectListItem { Value = "Juridico", Text = "Juridico" }
        };
        public CrearPatrocinadorModel(IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador = repoPatrocinador;
        }
        public ActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _creado = _repoPatrocinador.CrearPatrocinador(_patrocinador);
                if (_creado)
                {
                    TempData["mensajeCreado"] = "El patrocinador " + _patrocinador.Nombre + " se ha creado correctamente!";
                    return RedirectToPage("./VerPatrocinadores");
                }
                else
                {
                    ViewData["Mensaje"] = "El patrocinador identificado " + _patrocinador.Identificacion + " ya existe!";
                }
            }
            return Page();
        }
    }
}
