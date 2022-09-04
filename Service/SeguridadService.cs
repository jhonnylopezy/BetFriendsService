using BF.Domain.DTO;
using BF.Domain.Entity;
using BF.Domain.Interface;
using BF.Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SeguridadService : ISeguridadService
    {
        private readonly IParticipanteData _participanteData;
        private readonly IConfiguration _configuration;
        public SeguridadService(IParticipanteData _participanteData, IConfiguration _configuration)
        {
            this._participanteData = _participanteData;
            this._configuration = _configuration;

        }

        public Task<RespuestaModel<LoginDTO>> Autenticar(LoginRequestModel loginRequestModel)
        {
            return Utils.Metodo.FuncionConExcepcionAsync<LoginDTO>(async ()=>
            {
                var token = string.Empty;
                var participanteEntity =await this._participanteData.ValidarParticipante(loginRequestModel);

                if (participanteEntity != null)
                {
                    token = await this.ObtenerToken(participanteEntity);
                }
                
                return new LoginDTO
                {
                    token = token
                };
            });
        }

        private async Task<string> ObtenerToken(ParticipanteEntity participanteEntity)
        {
            try
            {
                // Tu código para validar que el usuario ingresado es válido
                //var usuarioEntidad = new UsuarioEntidad();
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken createdToken = null;
                participanteEntity.clave= Utils.Metodo.GenerarHash(participanteEntity.clave);
              //  var usuarioResultado = this.usuarioRepository.ObtenerUsuario(parObtenerUsuario).Result;
                //if (!usuarioResultado.Any())
                //    throw new ArgumentException("Usuario no autorizado");

                //usuarioEntidad = usuarioResultado.First();
                var secretKey = this._configuration.GetSection("SecretKey").Value;
                var tiempoDia = Convert.ToInt32(_configuration.GetSection("Dia").Value);

                var key = Encoding.ASCII.GetBytes(secretKey);

                // Creamos los claims (pertenencias, características) del usuario
                var claims = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, "a79b2e64-a4de-4f3a-8cf6-a68ba400db24"),
            new Claim(ClaimTypes.Email, participanteEntity.email),
            new Claim(ClaimTypes.Name, participanteEntity.usuario)            
            });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    // Nuestro token va a durar un día
                    //Expires = DateTime.UtcNow.AddMinutes(tiempoMinuto),
                    Expires = DateTime.UtcNow.AddDays(tiempoDia),
                    // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                createdToken = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(createdToken);
            }
            catch (Exception e)
            {

            }
            return string.Empty;
        }
    }
}
