using SOSBilbao.Models;
using SOSBilbao.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Services
{
    public interface IParadaTaxi
    {

        public Task<MostrarParadasTaxiVM> GetParadaTaxiAsync(string zona,string nombre);
        public Task<ParadaTaxi> GetParadaTaxiByIdAsync(int? id);
        public Task CreateParadaTaxiAsync(ParadaTaxi paradaTaxi);
        public Task UpdateParadaTaxiAsync(ParadaTaxi paradaTaxi);
        public Task DeleteParadaTaxiAsync(ParadaTaxi paradaTaxi);
        public bool ParadaTaxiExists(int id);

    }
}
