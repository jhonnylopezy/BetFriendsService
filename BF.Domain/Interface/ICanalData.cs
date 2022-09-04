using BF.Domain.DTO;
using BF.Domain.Entity;
using BF.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BF.Domain.Interface
{
    public interface ICanalData
    {
        Task<IEnumerable<CanalEntity>> ObtenerCanales();
        Task<IEnumerable<CanalEntity>> ObtenerCanalesPorParticipante(int idParticipante);
        Task<IEnumerable<RespuestaFunctionModel>> RegistrarParticipante(ParticipanteCanalDTO participanteCanalDTO);
    }
}
