using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.Entity
{
   public class JornadaEntity
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string fecha_creacion { get; set; }
        public string fecha_modificacion { get; set; }
    }
}
