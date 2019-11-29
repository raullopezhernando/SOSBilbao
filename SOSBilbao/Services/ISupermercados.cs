using Microsoft.AspNetCore.Mvc;
using SOSBilbao.Models;
using SOSBilbao.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Services
{
    public interface ISupermercados
    {
       
        public Task<MostrarSupermercadosVM> GetSupermercadosAsync(string zona,string nombre);
        public Task<Supermercado> GetSupermercadoByIdAsync(int? id);
        public Task CreateSupermercadoAsync(Supermercado supermercado);
        public Task UpdateSupermercadoAsync(Supermercado supermercado);
        public Task DeleteSupermercadoAsync(Supermercado supermercado);
        public bool SupermercadoExists(int id);


    }
}
