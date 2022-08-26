using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.DTO
{
  public  class PartidoDTO
    {
        public long id { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string lugar { get; set; }
        public string estado { get; set; }
        public bool empate { get; set; }
        public long id_jornada { get; set; }
        
    }
}
