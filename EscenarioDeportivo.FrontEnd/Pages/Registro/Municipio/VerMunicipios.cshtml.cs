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
    public class VerMunicipiosModel : PageModel
    {
        public readonly IRepositorioMunicipio _repoMunicipio;
        [BindProperty]
        public IEnumerable<Municipio> listaMunicipios { get; set;}

        public VerMunicipiosModel(IRepositorioMunicipio repoMunicipio)
        {
            this._repoMunicipio = repoMunicipio;
        }
        
        public void OnGet()
        {
            listaMunicipios = _repoMunicipio.ListarMunicipios();
        }
    }
}
