using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Models
{
    public class UsuarioParadasTaxi
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }
        public int ParadaTaxiId { get; set; }
        public ParadaTaxi ParadaTaxi { get; set; }

    }
 }