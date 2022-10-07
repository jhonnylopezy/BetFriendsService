using BF.Domain;
using BF.Domain.DTO;
using BF.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetFriends.FE.Service
{
    public class ParticipanteService
    {
        public ParticipanteService()
        {

        }
        public ParticipanteDTO ObtenerParticipante(string usuario,string clave)
        {
            var urlRequest = ParticipanteMethod.OBTENER_PARTICIPANTE;
            var loginRequest = new LoginRequestModel()
            {
                clave = clave,
                usuario = usuario
            };
            var param = JsonConvert.SerializeObject(loginRequest);
            var resultadoPeticion = Utils.Metodo.EjecutarPeticion<RespuestaModel<ParticipanteDTO>>(urlRequest, param, RequestType.POST);

            return resultadoPeticion.data;

        }
    }
}