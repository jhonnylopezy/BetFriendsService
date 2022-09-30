using BF.Domain;
using BF.Domain.DTO;
using BF.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetFriends.FE.Service
{
    public class JornadaService
    {
        public List<JornadaDTO> Listar()
        {
            var urlRequest = JornadaMethod.LISTAR;
            var resultadoPeticion = Utils.Metodo.EjecutarPeticion<RespuestaModel<List<JornadaDTO>>>(urlRequest, null, RequestType.GET);

            return resultadoPeticion.data;
        }
    }
}