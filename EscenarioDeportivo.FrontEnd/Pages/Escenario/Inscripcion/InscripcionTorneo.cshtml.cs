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
    public class InscripcionTorneoModel : PageModel
    {
        public readonly IRepositorioTorneoEquipo _repoTorneoEquipo;
        public readonly IRepositorioTorneo _repoTorneo;
        public readonly IRepositorioEquipo _repoEquipo;
        [BindProperty]
        public TorneoEquipo _torneoEquipo { get; set; }
        public Torneo _torneo { get; set; }
        public IEnumerable<TorneoEquipo> _listarTorneoEquipos { get; set; }
        //public IEnumerable<Torneo> _listaTorneos { get; set; }
        public List<Torneo> _listaTorneos = new List<Torneo>();
        //public IEnumerable<Equipo> _listaEquipos { get; set; }
        public List<Equipo> _listaEquipos = new List<Equipo>();
        public List<VistaTorneoEquipo> _listaVistaTorneoEquipo = new List<VistaTorneoEquipo>();

        public InscripcionTorneoModel(IRepositorioTorneoEquipo repoTorneoEquipo, IRepositorioTorneo repoTorneo, IRepositorioEquipo repoEquipo)
        {
            this._repoTorneoEquipo = repoTorneoEquipo;
            this._repoTorneo = repoTorneo;
            this._repoEquipo = repoEquipo;
            _listaTorneos = _repoTorneo.ListarTorneosList();
            _listaEquipos = _repoEquipo.ListarEquiposList();
            _listarTorneoEquipos = _repoTorneoEquipo.ListarTorneosEquipos();
        }
        public ActionResult OnGet()
        {
            if (_listaTorneos != null && _listaTorneos.Count() > 0)
            {
                if (_listaEquipos != null && _listaEquipos.Count() > 0)
                {
                    VistaTorneoEquipo vistaTorneoEquipo = null;
                    foreach (var LTorEqu in _listarTorneoEquipos)
                    {
                        vistaTorneoEquipo = new VistaTorneoEquipo();
                        foreach (var LTor in _listaTorneos)
                        {
                            if (LTorEqu.TorneoId == LTor.Id)
                            {
                                vistaTorneoEquipo.TorneoNombre = LTor.Nombre;
                                vistaTorneoEquipo.TorneoTipo = LTor.Tipo;
                                break;
                            }
                        }
                        foreach (var LEqu in _listaEquipos)
                        {
                            if (LTorEqu.EquipoId == LEqu.Id)
                            {
                                vistaTorneoEquipo.EquipoNombre = LEqu.Nombre;
                                vistaTorneoEquipo.EquipoDisciplina = LEqu.Disciplina;
                                break;
                            }
                        }
                        vistaTorneoEquipo.TorneoId = LTorEqu.TorneoId;
                        vistaTorneoEquipo.EquipoId = LTorEqu.EquipoId;
                        _listaVistaTorneoEquipo.Add(vistaTorneoEquipo);
                    }
                    return Page();
                }
                else
                {
                    TempData["mensajeCreado"] = "Para realizar la inscripción debe registrar Equipos.";
                    return Page();
                }
            }
            else
            {
                TempData["mensajeCreado"] = "Para realizar la inscripción debe registrar Torneos.";
                return Page();
            }
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                String nombreEquipo = "";
                String nombreTorneo = "";
                bool _creado = _repoTorneoEquipo.CrearTorneoEquipo(_torneoEquipo);
                foreach (var LTor in _listaTorneos)
                {
                    if (_torneoEquipo.TorneoId == LTor.Id)
                    {
                        nombreTorneo = LTor.Nombre;
                        break;
                    }
                }
                foreach (var LEqu in _listaEquipos)
                {
                    if (_torneoEquipo.EquipoId == LEqu.Id)
                    {
                        nombreEquipo = LEqu.Nombre;
                        break;
                    }
                }
                if (_creado)
                {
                    TempData["mensajeCreado"] = "El equipo " + nombreEquipo + " se ha asignado al torneo " + nombreTorneo;
                }
                else
                {
                    TempData["mensajeCreado"] = "El equipo " + nombreEquipo + " ya está asignado al torneo " + nombreTorneo;
                }
            }
            VistaTorneoEquipo vistaTorneoEquipo = null;
            foreach (var LTorEqu in _listarTorneoEquipos)
            {
                vistaTorneoEquipo = new VistaTorneoEquipo();
                foreach (var LTor in _listaTorneos)
                {
                    if (LTorEqu.TorneoId == LTor.Id)
                    {
                        vistaTorneoEquipo.TorneoNombre = LTor.Nombre;
                        vistaTorneoEquipo.TorneoTipo = LTor.Tipo;
                        break;
                    }
                }
                foreach (var LEqu in _listaEquipos)
                {
                    if (LTorEqu.EquipoId == LEqu.Id)
                    {
                        vistaTorneoEquipo.EquipoNombre = LEqu.Nombre;
                        vistaTorneoEquipo.EquipoDisciplina = LEqu.Disciplina;
                        break;
                    }
                }
                vistaTorneoEquipo.TorneoId = LTorEqu.TorneoId;
                vistaTorneoEquipo.EquipoId = LTorEqu.EquipoId;
                _listaVistaTorneoEquipo.Add(vistaTorneoEquipo);
            }
            return Page();
        }
    }
}
