using BF.Domain;
using BF.Domain.DTO;
using BF.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetFriends.FE.Integration
{
    public class PronosticoService
    {

        public List<PronosticoDTO> getPronosticoPorCanal(int codCanal)
        {
            var urlRequest = PronosticoMethod.PRONOSTICO_X_CANAL + "/" + codCanal;
            
            var resultadoPeticion=Utils.Metodo.EjecutarPeticion<RespuestaModel<List<PronosticoDTO>>>(urlRequest, null,RequestType.GET);
           
            return resultadoPeticion.data;
        }
    }
}