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
    public class VerDeportistasModel : PageModel
    {
        public readonly IRepositorioDeportista _repoDeportista;
        public readonly IRepositorioEquipo _repoEquipo;
        [BindProperty]
        public IEnumerable<Deportista> _listaDeportistas { get; set; }
        public List<VistaDeportista> _listaVistaDeportista = new List<VistaDeportista>();

        public VerDeportistasModel(IRepositorioEquipo repoEquipo, IRepositorioDeportista repoDeportista)
        {
            this._repoEquipo = repoEquipo;
            this._repoDeportista = repoDeportista;
        }
        public void OnGet()
        {
            _listaDeportistas = _repoDeportista.ListarDeportistas();
            List<Equipo> listaEquipos = _repoEquipo.ListarEquiposList();
            VistaDeportista vistaDeportista = null;
            foreach (var LDep in _listaDeportistas)
            {
                vistaDeportista = new VistaDeportista();
                foreach (var LEqu in listaEquipos)
                {
                    if (LDep.EquipoId == LEqu.Id)
                    {
                        vistaDeportista.EquipoId = LEqu.Id;
                        vistaDeportista.EquipoNombre = LEqu.Nombre;
                        vistaDeportista.EquipoDisciplina = LEqu.Disciplina;
                        break;
                    }
                }
                vistaDeportista.Id = LDep.Id;
                vistaDeportista.Documento = LDep.Documento;
                vistaDeportista.Nombres = LDep.Nombres;
                vistaDeportista.Apellidos = LDep.Apellidos;
                vistaDeportista.Genero = LDep.Genero;
                vistaDeportista.Rh = LDep.Rh;
                vistaDeportista.EPS = LDep.EPS;
                vistaDeportista.FechaNacimiento = LDep.FechaNacimiento;
                vistaDeportista.Disciplina = LDep.Disciplina;
                vistaDeportista.Direccion = LDep.Direccion;
                _listaVistaDeportista.Add(vistaDeportista);
            }
        }
    }
}
