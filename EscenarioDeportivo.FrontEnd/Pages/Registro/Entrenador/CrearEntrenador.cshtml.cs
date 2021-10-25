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
    public class CrearEntrenadorModel : PageModel
    {
        public readonly IRepositorioEntrenador _repoEntrenador;
        public readonly IRepositorioEquipo _repoEquipo;
        [BindProperty]
        //public Equipo.Entrenador _entrenador { get; set; }
        public Equipo _equipo { get; set; }
        public List<SelectListItem> listaGenero { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Masculino", Text = "Masculino" },
            new SelectListItem { Value = "Femenino", Text = "Femenino" }
        };

        public CrearEntrenadorModel(IRepositorioEquipo repoEquipo, IRepositorioEntrenador repoEntrenador)
        {
            this._repoEquipo = repoEquipo;
            this._repoEntrenador = repoEntrenador;
        }
        public ActionResult OnGet(Equipo equipo)
        {
            _equipo = equipo;
            _equipo.Entrenador = new Entrenador();            
            return Page();
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bool _creado = _repoEquipo.CrearEquipo(_equipo);
                if (_creado)
                {
                    TempData["mensajeCreado"] = "El equipo " + _equipo.Nombre + " y entrenador " + _equipo.Entrenador.Nombres + " se han creado correctamente!";
                    return RedirectToPage("../Equipo/VerEquipos");
                }
                else
                {
                    ViewData["Mensaje"] = "El entrenador " + _equipo.Entrenador.Nombres + " ya existe!";
                }
                
                //ViewData["Mensaje"] = "Equipo: " + _equipo.Nombre + ". " + _equipo.Disciplina + ".";
                //ViewData["Mensaje"] = ViewData["Mensaje"] + " Entrenador: " + _equipo.Entrenador.Documento + ". " + _equipo.Entrenador.Nombres;
            }
            return Page();
        }
    }
}
