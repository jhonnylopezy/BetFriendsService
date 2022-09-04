using BF.Domain.DTO;
using BF.Domain.Interface;
using BF.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetFriendsService.Controllers.Seguridad
{
    [Route("api/[controller]/[action]")]
    public class SeguridadController : Controller
    {
        private readonly ISeguridadService _seguridadService;
        public SeguridadController(ISeguridadService _seguridadService)
        {
            this._seguridadService = _seguridadService;
        }

        [HttpGet]
        [Route("Ping")]
        public ActionResult Ping()
        {
            return Ok(true);
        }
    
        [HttpPost]
        
        public async Task<ActionResult<RespuestaModel<LoginDTO>>> Autenticar([FromBody] LoginRequestModel loginModel)
        {
            var result = await this._seguridadService.Autenticar(loginModel);
            return Ok(result);
        }
    }
}
