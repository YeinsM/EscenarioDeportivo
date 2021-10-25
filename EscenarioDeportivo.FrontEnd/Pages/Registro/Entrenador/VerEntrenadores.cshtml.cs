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
    public class VerEntrenadoresModel : PageModel
    {
        public readonly IRepositorioEntrenador _repoEntrenador;
        public readonly IRepositorioEquipo _repoEquipo;
        [BindProperty]
        public IEnumerable<Entrenador> _listaEntrenadores { get; set; }
        public List<VistaEntrenador> _listaVistaEntrenador = new List<VistaEntrenador>();

        public VerEntrenadoresModel(IRepositorioEquipo repoEquipo, IRepositorioEntrenador repoEntrenador)
        {
            this._repoEquipo = repoEquipo;
            this._repoEntrenador = repoEntrenador;
        }
        public void OnGet()
        {
            _listaEntrenadores = _repoEntrenador.ListarEntrenadores();
            List<Equipo> listaEquipos = _repoEquipo.ListarEquiposList();
            if (listaEquipos.Count() < 1)
            {
                TempData["mensajeCreado"] = "Para crear un Entrenador se realiza desde agregar el Equipo.";
            }
            VistaEntrenador vistaEntrenador = null;
            foreach (var LEnt in _listaEntrenadores)
            {
                vistaEntrenador = new VistaEntrenador();
                foreach (var LEqu in listaEquipos)
                {
                    if (LEnt.EquipoId == LEqu.Id)
                    {
                        vistaEntrenador.NombreEquipo = LEqu.Nombre;
                        vistaEntrenador.DisciplinaEquipo = LEqu.Disciplina;
                        break;
                    }
                }
                vistaEntrenador.Id = LEnt.Id;
                vistaEntrenador.Documento = LEnt.Documento;
                vistaEntrenador.Nombres = LEnt.Nombres;
                vistaEntrenador.Apellidos = LEnt.Apellidos;
                vistaEntrenador.Genero = LEnt.Genero;
                vistaEntrenador.DisciplinaDeportiva = LEnt.DisciplinaDeportiva;
                vistaEntrenador.DisciplinaDeportiva = LEnt.DisciplinaDeportiva;
                _listaVistaEntrenador.Add(vistaEntrenador);
            }
        }
    }
}
