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
    public class CanalService
    {
        public List<CanalDTO> ObtenerCanales()
        {
            var urlRequest = CanalMethod.LISTAR;
            var resultadoPeticion = Utils.Metodo.EjecutarPeticion<RespuestaModel<List<CanalDTO>>>(urlRequest, null, RequestType.GET);

            return resultadoPeticion.data;
        }
        public List<CanalDTO> CanalesXParticipante(int codParticipante)
        {
            var urlRequest = CanalMethod.CANALES_X_PARTICIPANTE+ "/" + codParticipante;
            var resultadoPeticion = Utils.Metodo.EjecutarPeticion<RespuestaModel<List<CanalDTO>>>(urlRequest, null, RequestType.GET);

            return resultadoPeticion.data;
        }
        public string SuscribirParticipante(ParticipanteCanalDTO participanteCanalDTO)
        {
            var urlRequest = CanalMethod.REGISTRAR_PARTICIPANTE_EN_CANAL;
            var parametro = JsonConvert.SerializeObject(participanteCanalDTO);
            var resultadoPeticion = Utils.Metodo.EjecutarPeticion<RespuestaModel<List<PronosticoDTO>>>(urlRequest, parametro, RequestType.POST);

            return resultadoPeticion.errCode;
        }
    }
}