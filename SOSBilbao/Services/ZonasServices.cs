using Microsoft.EntityFrameworkCore;
using SOSBilbao.Data;
using SOSBilbao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Services
{
    public class ZonasServices : IZonas
    {
        private readonly ApplicationDbContext _context;

        public ZonasServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateZonaAsync(Zona zona)
        {
            await _context.AddAsync(zona);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteZonaAsync(Zona zona)
        {
            _context.Zona.Remove(zona);
            await _context.SaveChangesAsync();
        }

        public async Task<Zona> GetZonaByIdAsync(int? id)
        {
            return await _context.Zona.FindAsync(id);
        }

        public async Task<List<Zona>> GetZonasAsync()
        {
            return await _context.Zona.ToListAsync();
        }


        public async Task UpdateZonaAsync(Zona zona)
        {
            _context.Update(zona);
            await _context.SaveChangesAsync();
        }

        public bool ZonaExists(int id)
        {
            return _context.Zona.Any(e => e.Id == id);
        }


    }
}
