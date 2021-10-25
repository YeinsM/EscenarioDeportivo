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
    public class CrearEquipoModel : PageModel
    {
        public readonly IRepositorioEquipo _repoEquipo;
        public readonly IRepositorioPatrocinador _repoPatrocinador;
        [BindProperty]
        public Equipo _equipo { get; set; }
        public IEnumerable<Patrocinador> _listaPatrocinadores { get; set; }
        //public List<Patrocinador> _listaPatrocinadores { get; set; }

        public CrearEquipoModel(IRepositorioEquipo repoEquipo, IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoEquipo = repoEquipo;
            this._repoPatrocinador = repoPatrocinador;
            _listaPatrocinadores = _repoPatrocinador.ListarPatrocinadores();
        }
        public ActionResult OnGet()
        {
            //_listaPatrocinadores = _repoPatrocinador.ListarPatrocinadores();
            if (_listaPatrocinadores != null && _listaPatrocinadores.Count() > 0)
            {
                return Page();
            }
            else
            {
                TempData["mensajeCreado"] = "Para crear un Equipo debe crear primero Patrocinadores.";
                return RedirectToPage("./VerEquipos");
            }
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                /*
                bool _creado = _repoEquipo.CrearEquipo(_equipo);
                if (_creado)
                {
                    TempData["mensajeCreado"] = "El equipo " + _equipo.Nombre + " se ha creado correctamente!";
                    return RedirectToPage("./VerEquipos");
                }
                else
                {
                    ViewData["Mensaje"] = "El equipo " + _equipo.Nombre + " ya existe!";
                }
                */
                Equipo equipoVerifica = _repoEquipo.BuscarEquipo(_equipo);
                if (equipoVerifica == null)
                {
                    return RedirectToPage("../Entrenador/CrearEntrenador", _equipo);
                }
                else
                {
                    ViewData["Mensaje"] = "El equipo " + _equipo.Nombre + " ya existe!";
                }
            }
            return Page();
        }
    }
}
