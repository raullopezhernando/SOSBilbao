using SOSBilbao.Models;
using SOSBilbao.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Services
{
   public interface IFarmacia
    {
        public Task<MostrarFarmaciasVM> GetFarmaciaAsync(string zona,string nombre);
        public Task<Farmacia> GetFarmaciaByIdAsync(int? id);
        public Task CreateFarmaciaAsync(Farmacia farmacia);
        public Task UpdateFarmaciaAsync(Farmacia farmacia);
        public Task DeleteFarmaciaAsync(Farmacia farmacia);
        
        public bool FarmaciaExists(int id);


    }
}
