using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.Entity
{
    public class ParticipanteEntity
    {
        public string id { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string email { get; set; }
        public string estado { get; set; }
        public string imagen { get; set; }
        public string fecha_creacion { get; set; }
        public string fecha_modificacion { get; set; }
    }
}
