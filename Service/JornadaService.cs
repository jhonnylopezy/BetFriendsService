using BF.Domain.DTO;
using BF.Domain.Interface;
using BF.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class JornadaService : IJornadaService
    {
        private readonly IJornadaData _jornadaData;
        public JornadaService(IJornadaData jornadaData)
        {
            this._jornadaData = jornadaData;
        }
        public async Task<RespuestaModel<List<JornadaDTO>>> ObtenerJornadas()
        {
            return await Utils.Metodo.FuncionConExcepcionAsync<List<JornadaDTO>>(async () =>
            {
                var resultadoEntity = await this._jornadaData.ObtenerJornadas();
                var resultadoDTO = resultadoEntity.Select(jornada => new JornadaDTO
                {
                    id=jornada.id,
                    estado=jornada.estado,
                    nombre=jornada.nombre                    
                }).ToList();

                return resultadoDTO;
            });

        }
    }
}
