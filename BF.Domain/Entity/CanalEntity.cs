using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.Entity
{
    public class CanalEntity
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string limite { get; set; }
        public string clave { get; set; }
        public string estado { get; set; }
        public string fecha_creacion { get; set; }
        public string fecha_modificacion { get; set; }
    }
}
