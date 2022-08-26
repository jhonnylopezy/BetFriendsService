﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.Entity
{
   public class JornadaEntity
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
}
