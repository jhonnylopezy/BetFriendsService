using BF.Domain.DTO;
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
    public class PartidoData : IPartidoData
    {
        public NpgsqlConnection conexion;
        public string cadenaConexion;
        public PartidoData(IConfiguration configuration)
        {
            this.cadenaConexion = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
        public async Task<IEnumerable<PartidoDTO>> ObtenerPartidoXJornada(int idJornada)
        {
            IEnumerable<PartidoDTO> respuesta = null;
            var sql = @"SELECT * FROM bet.obtener_partidos_x_jornada(@id_jornada)";
            var sqlParam = new
            {
                id_jornada = idJornada
            };

            using (var connection = new NpgsqlConnection(this.cadenaConexion))
            {
                respuesta = await connection.QueryAsync<PartidoDTO>(sql, sqlParam);
            }
            return respuesta;
        }
    }
}
