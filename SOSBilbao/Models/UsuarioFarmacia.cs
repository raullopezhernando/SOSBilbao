using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Models
{
    public class UsuarioFarmacia
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int FarmaciaId { get; set; }
        public Farmacia Farmacia { get; set; }
    }
}
