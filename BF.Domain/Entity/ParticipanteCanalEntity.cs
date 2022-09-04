using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.Entity
{
    public class ParticipanteCanalEntity
    {
        public string id { get; set; }
        public string id_participante { get; set; }
        public string id_canal { get; set; }
        public string orden { get; set; }
        public string estado { get; set; }
        public string fecha_creacion { get; set; }
        public string fecha_modificacion { get; set; }
    }
}
