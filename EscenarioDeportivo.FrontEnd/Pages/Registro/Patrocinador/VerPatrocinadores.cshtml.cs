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
    public class VerPatrocinadoresModel : PageModel
    {
        public readonly IRepositorioPatrocinador _repoPatrocinador;
        [BindProperty]
        public IEnumerable<Patrocinador> listaPatrocinadores { get; set;}

        public VerPatrocinadoresModel(IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador = repoPatrocinador;
        }
        public void OnGet()
        {
            listaPatrocinadores = _repoPatrocinador.ListarPatrocinadores();
        }
    }
}
