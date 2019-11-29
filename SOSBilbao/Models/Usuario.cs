using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Models
{
    //Clase que hereda de "IdentityUser". Estos atributos se añadiran a "IdentityUser"

    public class Usuario:IdentityUser
    {
        [MaxLength(30)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(30)]
        [Required]
        public string Apellido { get; set; }
        public string? Imagen { get; set; }
        public string? DireccionResidencia { get; set; }
        public string? DireccionTrabajo { get; set; }

        public List<UsuarioSupermercado> UsuarioSupermercados { get; set; }
        public List<UsuarioFarmacia> UsuarioFarmacias { get; set; }

        public List<UsuarioParadasTaxi> UsuarioParadasTaxis { get; set; }


    }
}
