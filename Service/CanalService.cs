using BF.Domain.DTO;
using BF.Domain.Interface;
using BF.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CanalService : ICanalService
    {
        private readonly ICanalData _canalData;
        public CanalService(ICanalData canalData) {
            this._canalData = canalData;
        }
        public async Task<RespuestaModel<List<CanalDTO>>> ObtenerCanales()
        {
            return await Utils.Metodo.FuncionConExcepcionAsync<List<CanalDTO>>(async () =>
            {
                var resultadoEntity = await this._canalData.ObtenerCanales();
                var resultadoDTO = resultadoEntity.Select(canal => new CanalDTO
                {
                    id = canal.id,
                    clave = canal.clave,
                    estado = canal.estado,
                    limite = canal.limite,
                    nombre = canal.nombre
                }).ToList();

                return resultadoDTO;
            });
               
        }

        public async Task<RespuestaModel<List<CanalDTO>>> ObtenerCanalesPorParticipante(int id_participante)
        {
            var parametro=JsonConvert.SerializeObject(new{ id_participante= id_participante });
           return await Utils.Metodo.FuncionConExcepcionAsync<List<CanalDTO>>(async() =>{
                var resultadoEntity = await this._canalData.ObtenerCanalesPorParticipante(id_participante);
                var resultadoDTO = resultadoEntity.Select(canal => new CanalDTO
                {
                    id = canal.id,
                    clave = canal.clave,
                    estado = canal.estado,
                    limite = canal.limite,
                    nombre = canal.nombre
                }).ToList();

                return resultadoDTO;
            });
            
        }

        public async Task<RespuestaModel<string>> RegistrarParticipante(ParticipanteCanalDTO participanteCanalDTO)
        {
            return await Utils.Metodo.FuncionConExcepcionAsync<string>(async () =>
            {
                var resultadoRegistro = await this._canalData.RegistrarParticipante(participanteCanalDTO);
                return resultadoRegistro.First().returns;
            });
        }
    }
}
