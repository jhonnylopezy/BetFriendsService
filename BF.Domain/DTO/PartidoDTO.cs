using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.DTO
{
    public class PartidoDTO
    {
        public long id_partido { get; set; }
        public string estado_partido { get; set; }
        public bool empate { get; set; }
        public DateTime fecha_partido { get; set; }
        public string hora_partido { get; set; }
        public string lugar { get; set; }
        public int cantidad_gol { get; set; }
        public string nombre_equipo { get; set; }
        public string pais_equipo { get; set; }
        public string tipo_equipo { get; set; }
        public string imagen { get; set; }
        public long id_grupo { get; set; }
        public long id_partido_equipo { get; set; }

    }
}
