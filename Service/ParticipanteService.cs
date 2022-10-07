using BF.Domain.DTO;
using BF.Domain.Entity;
using BF.Domain.Interface;
using BF.Domain.Model;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class ParticipanteService:IParticipanteService
    {
        private IParticipanteData _participanteData;
        public ParticipanteService(IParticipanteData participanteData) {

            this._participanteData = participanteData;
        }

        public async Task<ParticipanteDTO> CrearParticipante(ParticipanteModel participanteModel)
        {
            var participanteEntity = await this._participanteData.CrearParticipante(participanteModel);
            var participante = new ParticipanteDTO
            {
                id = participanteEntity.id,
                usuario = participanteEntity.usuario,
                email = participanteEntity.email,
                estado = participanteEntity.estado,
                imagen = participanteEntity.imagen
            };

            return participante;
        }

        public async Task<RespuestaModel<ParticipanteDTO>> Get(LoginRequestModel loginRequestModel)
        {
            //var participanteEntity = await this._participanteData.ValidarParticipante(loginRequestModel);
            //var participante = new ParticipanteDTO
            //{
            //    id = participanteEntity.id,
            //    usuario = participanteEntity.usuario,
            //    email = participanteEntity.email,
            //    estado = participanteEntity.estado,
            //    imagen = participanteEntity.imagen
            //};

            //return participante;
            return await Utils.Metodo.FuncionConExcepcionAsync<ParticipanteDTO>( async() => {
                var participanteEntity = await this._participanteData.ValidarParticipante(loginRequestModel);
                var participante = new ParticipanteDTO
                {
                    id = participanteEntity.id,
                    usuario = participanteEntity.usuario,
                    email = participanteEntity.email,
                    estado = participanteEntity.estado,
                    imagen = participanteEntity.imagen
                };

                return participante;
            });
        }
    }
}
