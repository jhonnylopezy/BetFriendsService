using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.Interface
{
    public interface IPartidoData
    {
        Task<IEnumerable<PartidoEntity>> ObtenerCanalesPorParticipante(int idJornada);
    }
}
