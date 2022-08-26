using BF.Domain.Entity;
using BF.Domain.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BF.DataAccess
{
    public class JornadaData : IJornadaData
    {
        public NpgsqlConnection conexion;
        public string cadenaConexion;
        public JornadaData(IConfiguration configuration)
        {
            this.cadenaConexion = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
        public async Task<IEnumerable<JornadaEntity>> ObtenerJornadas()
        {
            IEnumerable<JornadaEntity> respuesta = null;
            var sql = @"SELECT * FROM bet.obtener_jornadas()";
            var sqlParam = new { };

            using (var connection = new NpgsqlConnection(this.cadenaConexion))
            {
                respuesta = await connection.QueryAsync<JornadaEntity>(sql);
            }
            return respuesta;
        }
    }
}
