using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Models
{
    public class Supermercado
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }
        public Zona Zona { get; set; }

        public string Imagen { get; set; }
        public List<UsuarioSupermercado> usuarioSupermercados{ get; set; }



    }
}
