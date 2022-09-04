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
    [Authorize]
    public class PronosticoController : Controller
    {
        public IPronosticoService _pronosticoService;
        public PronosticoController(IPronosticoService _pronosticoService)
        {
            this._pronosticoService = _pronosticoService;
        }
        [HttpPost]        
        public async Task<ActionResult<RespuestaModel<string>>> Registrar([FromBody]PronosticoPartidoDTO pPronostico)
        {
            var resultado = await this._pronosticoService.Registrar(pPronostico);
            return Ok(resultado);
        }
        [HttpGet]
        [Route("{id_canal}")]
        public async Task<ActionResult<RespuestaModel<PronosticoDTO>>> ListarPorCanal(int id_canal)
        {
            var resultado = await this._pronosticoService.PronosticoXCanal(id_canal);
            return Ok(resultado);
        }
    }
}
