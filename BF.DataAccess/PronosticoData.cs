using BF.Domain.DTO;
using BF.Domain.Entity;
using BF.Domain.Interface;
using BF.Domain.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BF.DataAccess
{
   public  class PronosticoData:IPronosticoData
    {
        public string connectionString;
        public PronosticoData(IConfiguration configuration)
        {
            this.connectionString = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }

        public async Task<IEnumerable<RespuestaFunctionModel>> Registrar(string pronosticoData)
        {
            IEnumerable<RespuestaFunctionModel> respuesta = null;
            var sql = @"SELECT * FROM bet.registrar_pronostico(@pronostico_data)";
            var sqlParam = new
            {
                pronostico_data = pronosticoData
            };

            using (var connection = new NpgsqlConnection(this.connectionString))
            {
                respuesta = await connection.QueryAsync<RespuestaFunctionModel>(sql,sqlParam);
            }
            return respuesta;
        }
        public async Task<IEnumerable<PronosticoEntity>> ObtenerPronosticoXCanal(int id_canal)
        {
            IEnumerable<PronosticoEntity> respuesta = null;
            var sql = @"SELECT * FROM bet.obtener_pronosticos_x_canal(@id_canal)";
            var sqlParam = new
            {
                id_canal= id_canal
            };

            using (var connection = new NpgsqlConnection(this.connectionString))
            {
                respuesta = await connection.QueryAsync<PronosticoEntity>(sql, sqlParam);
            }
            return respuesta;
        }
    }
}
