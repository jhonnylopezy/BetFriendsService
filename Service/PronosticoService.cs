using BF.Domain.DTO;
using BF.Domain.Interface;
using BF.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Service
{
    public class PronosticoService : IPronosticoService
    {
        public IPronosticoData _pronosticoData;
       public PronosticoService(IPronosticoData _pronosticoData)
        {
            this._pronosticoData = _pronosticoData;
        }
        public async Task<RespuestaModel<string>> Registrar(PronosticoDTO pronosticoDTO)
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
