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
    public class VerTorneosModel : PageModel
    {
        public readonly IRepositorioTorneo _repoTorneo;
        public readonly IRepositorioMunicipio _repoMunicipio;
        [BindProperty]
        public IEnumerable<Torneo> _listaTorneos { get; set; }
        public List<VistaTorneo> _listavistaTorneo = new List<VistaTorneo>();

        public VerTorneosModel(IRepositorioTorneo repoTorneo,IRepositorioMunicipio repoMunicipio)
        {
            this._repoTorneo = repoTorneo;
            this._repoMunicipio = repoMunicipio;
        }
        public void OnGet()
        {
            _listaTorneos = _repoTorneo.ListarTorneos();
            List<Municipio> listaMunicipios = _repoMunicipio.ListarMunicipiosList();
            VistaTorneo vistaTorneo = null;
            foreach (var LTor in _listaTorneos)
            {
                vistaTorneo = new VistaTorneo();
                foreach (var LMun in listaMunicipios)
                {
                    if (LTor.MunicipioId == LMun.Id)
                    {
                        vistaTorneo.NombreMunicipio = LMun.Nombre;
                        break;
                    }
                }
                vistaTorneo.Id = LTor.Id;
                vistaTorneo.Nombre = LTor.Nombre;
                vistaTorneo.Categoria = LTor.Categoria;
                vistaTorneo.FechaInicial = LTor.FechaInicial;
                vistaTorneo.FechaFinal = LTor.FechaFinal;
                vistaTorneo.Tipo = LTor.Tipo;
                _listavistaTorneo.Add(vistaTorneo);
            }
        }
    }
}
