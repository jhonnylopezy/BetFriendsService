using BF.Domain.DTO;
using BF.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BF.Domain.Interface
{
    public interface IPronosticoService
    {
        Task<RespuestaModel<string>> Registrar(PronosticoPartidoDTO pronosticoDTO);
        Task<RespuestaModel<List<PronosticoDTO>>> PronosticoXCanal(int id_canal);
    }
}
