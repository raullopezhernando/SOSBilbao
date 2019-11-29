using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Models
{
    public class ParadaTaxi
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public Zona Zona { get; set; }

        public string Imagen { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public List<UsuarioParadasTaxi> usuarioParadasTaxis{ get; set; }


    }
}
