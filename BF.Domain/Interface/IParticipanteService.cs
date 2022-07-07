using BF.Domain.DTO;
using BF.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BF.Domain.Interface
{
    public interface IParticipanteService
    {
        Task<ParticipanteDTO> CrearParticipante(ParticipanteModel participanteModel);
    }
}
