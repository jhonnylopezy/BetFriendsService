using BF.Domain;
using BF.Domain.DTO;
using BF.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetFriends.FE.Service
{
    public class PartidoService
    {
        public List<PartidoDTO> PartidoXJornada(int idJornada)
        {
            var urlRequest = PartidoMethod.PARTIDO_X_JORNADA+ "/" + idJornada;

            var resultadoPeticion = Utils.Metodo.EjecutarPeticion<RespuestaModel<List<PartidoDTO>>>(urlRequest, null, RequestType.GET);

            return resultadoPeticion.data;

        }
    }
}