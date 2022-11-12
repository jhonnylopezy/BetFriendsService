using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.Entity
{
    public class ParticipanteEntity
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string email { get; set; }
        public string estado { get; set; }
        public string imagen { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
}
