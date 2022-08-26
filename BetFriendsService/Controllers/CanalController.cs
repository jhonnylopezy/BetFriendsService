using BF.Domain.DTO;
using BF.Domain.Interface;
using BF.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetFriendsService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CanalController : Controller
    {
        private readonly ICanalService _canalService;
        public CanalController(ICanalService _canalService)
        {
            this._canalService = _canalService;
        }
        // GET: CanalController
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<RespuestaModel<List<CanalDTO>>>> Listar()
        {
            var resultado= await this._canalService.ObtenerCanales();
            return Ok(resultado);
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
