using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Models
{
    public class Zona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Supermercado> supermercados { get; set; }
        public List<ParadaTaxi> paradastaxi { get; set; }

        public List<Farmacia> farmacias { get; set; }

    }
   

}       

