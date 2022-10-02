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
                var resultadoDTO = resultadoDTOIE.Select(partido => new PartidoDTO
                {
                    cantidad_gol = partido.cantidad_gol,
                    empate = partido.empate,
                    estado_partido = partido.estado_partido,
                    fecha_partido = partido.fecha_partido,
                    hora_partido = partido.hora_partido,
                    id_grupo = partido.id_grupo,
                    id_partido = partido.id_partido,
                    lugar = partido.lugar,
                    nombre_equipo = partido.nombre_equipo,
                    pais_equipo = partido.pais_equipo,
                    tipo_equipo = partido.tipo_equipo,
                    id_partido_equipo = partido.id_partido_equipo,
                    imagen=partido.imagen
                    
                }).ToList();
                return resultadoDTO;
            });
        }
    }
}
