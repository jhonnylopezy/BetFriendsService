using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetFriendsService.Controllers
{
    public class PartidoController : Controller
    {
        public IPartidoService _partidoService;
        public PartidoController()
        {

        }
        [HttpGet]
        [Route("{id_participante}")]
        public async Task<ActionResult<RespuestaModel<List<CanalDTO>>>> Participante(int id_participante)
        {
            var resultado = await this._canalService.ObtenerCanalesPorParticipante(id_participante);
            return Ok(resultado);
        }
    }
}
