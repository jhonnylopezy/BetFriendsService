using BF.Domain.DTO;
using BF.Domain.Interface;
using BF.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetFriendsService.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    public class PartidoController : Controller
    {

        public IPartidoService _partidoService;
        public PartidoController(IPartidoService _partidoService)
        {
            this._partidoService = _partidoService;
        }
        [HttpGet]
        [Route("{id_jornada}")]
        public async Task<ActionResult<RespuestaModel<List<PartidoDTO>>>> ListarXJornada(int id_jornada)
        {
            var resultado = await this._partidoService.ObtenerPartidosXJornada(id_jornada);
            return Ok(resultado);
        }
    }
}
