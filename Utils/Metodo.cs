using BF.Domain.Model;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Metodo
    {
        public static async Task<RespuestaModel<T>> FuncionConExcepcionAsync<T>(Func<Task<T>> fun)
        {
            try
            {
                return new RespuestaModel<T>
                {
                    errCode = string.Empty,
                    errMessage = string.Empty,
                    data = await fun()
                };
            }
            catch (ArgumentException ar)
            {
                return new RespuestaModel<T>
                {
                    errCode = ar.Message.Split('|')[0],
                    errMessage = ar.Message.Split('|')[1],
                    data= default(T)
                };
            }
            catch (Exception e)
            {

                return new RespuestaModel<T>
                {
                    errCode = "ERR001",
                    errMessage = "Error general de sistema",
                    data = default(T)
                };
            }
        }

        public static string GenerarHash(string jsonDato)
        {

            var res = "";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(jsonDato));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                res = Convert.ToString(builder);
                //  return builder.ToString();
            }
            return res;
        }
    }
}
