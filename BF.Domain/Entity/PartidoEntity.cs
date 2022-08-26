using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.Entity
{
    public class PartidoEntity
    {
        public long id { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string lugar { get; set; }
        public string estado { get; set; }
        public bool empate { get; set; }
        public long id_jornada { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
}
