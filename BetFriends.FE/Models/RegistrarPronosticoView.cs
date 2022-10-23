using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetFriends.FE.Models
{
    public class RegistrarPronosticoView
    {

        [Display(Name = "Usuario")]
        public string id_participante_canal { get; set; }
        public string nombre { get; set; }
        //[Required]
        //[Display(Name = "Email")]
        //public string gol_equipo2 { get; set; }
        //[Required]
        //[Display(Name = "Email")]
        //public string ganaEquipo { get; set; }
        //[Required]
        //[Display(Name = "Email")]
        //public string empata { get; set; }
        //[Required]
        //[Display(Name = "Email")]
        //public string ganaEquipo2 { get; set; }
    }
}