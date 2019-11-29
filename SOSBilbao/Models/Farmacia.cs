using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Models
{
    public class Farmacia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string HorarioAperturaMañana { get; set; }

        public string HorarioCierreMañana { get; set; }

        public string HorarioAperturaTarde { get; set; }

        public string HorarioCierreTarde { get; set; }

        public int ZonaId { get; set; }
        public string Longitud { get; set; }

        public string Latitud { get; set; }

        public Zona Zona { get; set; }

        public string Imagen { get; set; }
        public List<UsuarioFarmacia> usuarioFarmacias { get; set; }

    }
}
