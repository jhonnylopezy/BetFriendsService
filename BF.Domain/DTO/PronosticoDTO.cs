﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.DTO
{
    public class PronosticoDTO
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public int ordinal { get; set; }
        public string estado { get; set; }
        public int puntos { get; set; }
        public int id_participante_canal { get; set; }
        public DateTime fecha_creacion { get; set; }        
    }
}
