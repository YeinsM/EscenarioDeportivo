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
    public class VerEquiposModel : PageModel
    {
        public readonly IRepositorioEquipo _repoEquipo;
        public readonly IRepositorioPatrocinador _repoPatrocinador;
        [BindProperty]
        public IEnumerable<Equipo> _listaEquipos { get; set; }
        public List<VistaEquipo> _listaVistaEquipo = new List<VistaEquipo>();
        //public Patrocinador _patrocinador { get; set; }

        public VerEquiposModel(IRepositorioEquipo repoEquipo, IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoEquipo = repoEquipo;
            this._repoPatrocinador = repoPatrocinador;
        }
        public void OnGet()
        {
            _listaEquipos = _repoEquipo.ListarEquipos();
            List<Patrocinador> listaPatrocinadores = _repoPatrocinador.ListarPatrocinadoresList();
            VistaEquipo vistaEquipo = null;
            foreach (var LEqu in _listaEquipos)
            {
                vistaEquipo = new VistaEquipo();
                foreach (var LPat in listaPatrocinadores)
                {
                    if (LEqu.PatrocinadorId == LPat.Id)
                    {
                        vistaEquipo.PatrocinadorIdentificacion = LPat.Identificacion;
                        vistaEquipo.PatrocinadorNombre = LPat.Nombre;
                        break;
                    }
                }
                vistaEquipo.Id = LEqu.Id;
                vistaEquipo.Nombre = LEqu.Nombre;
                vistaEquipo.CantidadDeportistas = LEqu.CantidadDeportistas;
                vistaEquipo.Disciplina = LEqu.Disciplina;
                _listaVistaEquipo.Add(vistaEquipo);
            }
        }
    }
}