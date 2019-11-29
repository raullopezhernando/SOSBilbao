using SOSBilbao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Services
{
        public interface IZonas
        {
            public Task<List<Zona>> GetZonasAsync();
            public Task<Zona> GetZonaByIdAsync(int? id);
            public Task CreateZonaAsync(Zona zona);
            public Task UpdateZonaAsync(Zona zona);
            public Task DeleteZonaAsync(Zona zona);

            public bool ZonaExists(int id);
        }

       
    }

