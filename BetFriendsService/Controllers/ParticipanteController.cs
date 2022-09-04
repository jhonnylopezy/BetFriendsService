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
    public class ParticipanteController : Controller
    {
        private readonly IParticipanteService _participanteService;
        public ParticipanteController(IParticipanteService participanteService)
        {
            this._participanteService = participanteService;
        }


        // POST: ParticipanteController/Create
        [HttpPost]

        public async Task<ActionResult<ParticipanteDTO>> Create([FromBody] ParticipanteModel participanteModel)
        {
            var participante = await this._participanteService.CrearParticipante(participanteModel);
            return Ok(participante);
        }

    }
}
