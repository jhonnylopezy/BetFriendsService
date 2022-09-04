using BF.Domain.DTO;
using BF.Domain.Interface;
using BF.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BF.Domain.Entity;

namespace Service
{
    public class PronosticoService : IPronosticoService
    {
        public IPronosticoData _pronosticoData;
       public PronosticoService(IPronosticoData _pronosticoData)
        {
            this._pronosticoData = _pronosticoData;
        }

        public async Task<RespuestaModel<List<PronosticoDTO>>> PronosticoXCanal(int id_canal)
        {
            return await Utils.Metodo.FuncionConExcepcionAsync<List<PronosticoDTO>>(async () => {

                
                var resultadoLista = await this._pronosticoData.ObtenerPronosticoXCanal(id_canal);
                var resultadoDato = resultadoLista.Select(pronostico=>new PronosticoDTO{ 
                    estado= pronostico.estado,
                    fecha_creacion=pronostico.fecha_creacion,
                    id=pronostico.id,
                    id_participante_canal=pronostico.id_participante_canal,
                    nombre=pronostico.nombre,
                    ordinal=pronostico.ordinal,
                    puntos=pronostico.puntos
                }).ToList();

                return resultadoDato;
            });
        }

        public async Task<RespuestaModel<string>> Registrar(PronosticoPartidoDTO pronosticoDTO)
        {
            return await Utils.Metodo.FuncionConExcepcionAsync<string>(async ()=>{

                var paramJson = JsonConvert.SerializeObject(pronosticoDTO);
                var resultadoLista = await this._pronosticoData.Registrar(paramJson);
                var resultadoDato = resultadoLista.First().returns;
                
                return resultadoDato;
            });
        }
    }
}
