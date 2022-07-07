using BF.Domain.Entity;
using BF.Domain.Interface;
using BF.Domain.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Threading.Tasks;
using Dapper;

namespace BF.DataAccess
{
    public class ParticipanteData: IParticipanteData
    {
        public NpgsqlConnection conexion;
        public string cadenaConexion;
        public ParticipanteData(IConfiguration configuration)
        {
            this.cadenaConexion = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }

        public async Task<ParticipanteEntity> CrearParticipante(ParticipanteModel participanteModel)
        {
            var respuesta = new ParticipanteEntity();            
            var sql = @"SELECT * FROM bet.crear_participante2(@usuario,@clave,@email,@imagen) order by id desc";
            var sqlParam = new { usuario = participanteModel.usuario,
                                 clave = participanteModel.clave,
                                 email = participanteModel.email,
                                 imagen = participanteModel.imagen };
            using (var connection = new NpgsqlConnection(this.cadenaConexion))
            {
                respuesta = await connection.QueryFirstAsync<ParticipanteEntity>(sql, sqlParam);
            }
            return respuesta;
        }

        public async Task<ParticipanteEntity> ValidarParticipante(LoginRequestModel loginRequestModel)
        {
            var respuesta = new ParticipanteEntity();
            var sql = @"SELECT * FROM bet.validar_participante(@usuario,@clave)";
            var sqlParam = new
            {
                clave = loginRequestModel.clave,
                usuario = loginRequestModel.usuario
            };
            using (var connection = new NpgsqlConnection(this.cadenaConexion))
            {
                respuesta = await connection.QueryFirstAsync<ParticipanteEntity>(sql, sqlParam);
            }
            return respuesta;
        }
    }
}
