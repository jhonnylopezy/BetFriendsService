using BF.Domain.Entity;
using BF.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BF.Domain.Interface
{
   public interface IPronosticoData
    {
        Task<IEnumerable<RespuestaFunctionModel>> Registrar(string pronosticoData);
        Task<IEnumerable<PronosticoEntity>> ObtenerPronosticoXCanal(int id_canal);
    }
}
