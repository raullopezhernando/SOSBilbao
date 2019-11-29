using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Models
{
    public class UsuarioSupermercado
    {
        public int Id { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int IdSupermercado { get; set; }
        public Supermercado Supermercado { get; set; }
    

    }
}
