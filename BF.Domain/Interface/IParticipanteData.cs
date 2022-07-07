using BF.Domain.Model;
using BF.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BF.Domain.Interface
{
    public interface IParticipanteData
    {
        Task<ParticipanteEntity> CrearParticipante(ParticipanteModel participanteModel);
        Task<ParticipanteEntity> ValidarParticipante(LoginRequestModel loginRequestModel);
    }
}
