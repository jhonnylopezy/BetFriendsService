using BF.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.DTO
{
    public class PronosticoDTO
    {
        public long id_participante_canal{get;set;}
        public string nombre { get; set; }
        public List<PartidoModel> partidos { get; set; }
    }
}
