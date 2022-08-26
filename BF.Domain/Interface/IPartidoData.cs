using BF.Domain.DTO;
using BF.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BF.Domain.Interface
{
    public interface IPartidoData
    {
        Task<IEnumerable<PartidoDTO>> ObtenerPartidoXJornada(int idJornada);
    }
}
