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
    public class CrearDeportistaModel : PageModel
    {
        public readonly IRepositorioDeportista _repoDeportista;
        public readonly IRepositorioEquipo _repoEquipo;
        [BindProperty]
        public Deportista _deportista { get; set; }
        public IEnumerable<Equipo> _listaEquipos { get; set; }
        public List<SelectListItem> _listaGenero { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Masculino", Text = "Masculino" },
            new SelectListItem { Value = "Femenino", Text = "Femenino" }
        };

        public CrearDeportistaModel(IRepositorioDeportista repoDeportista, IRepositorioEquipo repoEquipo)
        {
            this._repoDeportista = repoDeportista;
            this._repoEquipo = repoEquipo;
            _listaEquipos = _repoEquipo.ListarEquipos();
        }
        public ActionResult OnGet()
        {
            if (_listaEquipos != null && _listaEquipos.Count() > 0)
            {
                return Page();
            }
            else
            {
                TempData["mensajeCreado"] = "Para crear un Deportista debe crear primero Equipos.";
                return RedirectToPage("./VerDeportistas");
            }
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _creado = _repoDeportista.CrearDeportista(_deportista);
                if (_creado)
                {
                    TempData["mensajeCreado"] = "El deportista " + _deportista.Nombres + " con documento " + _deportista.Documento + " se ha creado correctamente!";
                    return RedirectToPage("./VerDeportistas");
                }
                else
                {
                    ViewData["Mensaje"] = "El deportista " + _deportista.Nombres + " con documento " + _deportista.Documento + " ya existe!";
                }
            }
            return Page();
        }
    }
}
