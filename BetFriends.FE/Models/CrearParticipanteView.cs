using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetFriends.FE.Models
{
    public class CrearParticipanteView
    {
        [Required]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Introducir contraseña")]
        public string clave { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme su contraseña")]
        public string claveAConfirmar { get; set; }


    }
}