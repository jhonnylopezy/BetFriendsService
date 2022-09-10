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
    public class CanalData : ICanalData
    {
        public NpgsqlConnection conexion;
        public string cadenaConexion;
        public CanalData(IConfiguration configuration)
        {
            this.cadenaConexion = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
        public async Task<IEnumerable<CanalEntity>> ObtenerCanales()
        {
            IEnumerable<CanalEntity> respuesta = null;
            var sql = @"SELECT * FROM bet.obtener_canales()";
            var sqlParam = new {};

            using (var connection = new NpgsqlConnection(this.cadenaConexion))
            {
                respuesta = await connection.QueryAsync<CanalEntity>(sql);
            }
            return respuesta;
        }

        public async Task<IEnumerable<CanalEntity>> ObtenerCanalesPorParticipante(int idParticipante)
        {
            IEnumerable<CanalEntity> respuesta = null;
            var sql = @"SELECT * FROM bet.obtener_canales_por_participante(@id_participante)";
            var sqlParam = new {
                id_participante = idParticipante
            };

            using (var connection = new NpgsqlConnection(this.cadenaConexion))
            {
                respuesta = await connection.QueryAsync<CanalEntity>(sql,sqlParam);
            }
            return respuesta;
        }

        public async Task<IEnumerable<RespuestaFunctionModel>> RegistrarParticipante(ParticipanteCanalDTO participanteCanalDTO)
        {
            IEnumerable<RespuestaFunctionModel> respuesta = null;
            var sql = @"SELECT registrar_participante_en_canal as returns FROM bet.registrar_participante_en_canal(@id_participante,@id_canal)";
            var sqlParam = new
            {
                id_participante = participanteCanalDTO.id_participante,
                id_canal= participanteCanalDTO.id_canal
            };

            using (var connection = new NpgsqlConnection(this.cadenaConexion))
            {
                respuesta = await connection.QueryAsync<RespuestaFunctionModel>(sql, sqlParam);
            }
            return respuesta;
        }
    }
}
