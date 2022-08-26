using BF.Domain.DTO;
using BF.Domain.Interface;
using BF.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetFriendsService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class JornadaController : Controller
    {
        private readonly IJornadaService _jornadaService;
        public JornadaController(IJornadaService _jornadaService)
        {
            this._jornadaService = _jornadaService;
        }
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<RespuestaModel<List<JornadaDTO>>>> Listar()
        {
            var resultado = await this._jornadaService.ObtenerJornadas();
            return Ok(resultado);
        }
        
    }
}
