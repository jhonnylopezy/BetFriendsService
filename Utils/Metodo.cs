using BF.Domain.Model;
using System;
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
                    errCode = ar.Message.Split('|')[1],
                    errMessage = ar.Message.Split('|')[2],
                    data = default(T)
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
    }
}
