using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.DTO
{
    public class ParticipanteDTO
    {
        public int id { get; set; }
        public string usuario { get; set; }        
        public string email { get; set; }
        public string estado { get; set; }
        public string imagen { get; set; }        
    }
}
