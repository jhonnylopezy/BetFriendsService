using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.Model
{
    public class PartidoModel
    {
        public long id_partido{get;set;}
        public bool empate { get; set; }
        public List<Partido_EquipoModel> partido_equipos { get; set; }
    }
}
