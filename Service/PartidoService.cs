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
    public class PartidoService : IPartidoService
    {
        private readonly IPartidoData _partidoData;
        public PartidoService(IPartidoData _partidoData)
        {
            this._partidoData = _partidoData;
        }
        public async Task<RespuestaModel<List<PartidoDTO>>> ObtenerPartidosXJornada(int id_jornada)
        {
            return await Utils.Metodo.FuncionConExcepcionAsync<List<PartidoDTO>>(async () =>
            {
            var resultadoDTOIE = await this._partidoData.ObtenerPartidoXJornada(id_jornada);
            var resultadoDTO = resultadoDTOIE
                .GroupBy(equipo=>equipo.id_partido)
                .Select(equipo => equipo.First()).ToList()
                .Select(partido=>new PartidoDTO { 
                id_partido=partido.id_partido
                }).ToList();
                return resultadoDTO;
            });
        }
    }
}
