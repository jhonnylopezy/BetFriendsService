using BF.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BF.Domain.Interface
{
   public  interface IJornadaData
    {
        Task<IEnumerable<JornadaEntity>> ObtenerJornadas();
    }
}
