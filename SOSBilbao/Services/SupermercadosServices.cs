using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOSBilbao.Data;
using SOSBilbao.Models;
using SOSBilbao.Models.ViewModels;

namespace SOSBilbao.Services
{
    public class SupermercadosServices : ISupermercados
    {
        private readonly ApplicationDbContext _context;

        public SupermercadosServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task CreateSupermercadoAsync(Supermercado supermercado)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteSupermercadoAsync(Supermercado supermercado)
        {
            _context.Supermercado.Remove(supermercado);

            await _context.SaveChangesAsync();
        }

        // Seleccionar Supermercado por Id ---------------------------------------------------------------
        public async Task<Supermercado> GetSupermercadoByIdAsync(int? id)
        {
            return await _context.Supermercado.FindAsync(id);
        }

        //-----------------------------------------------------------------------------------------------------------
       
        // Seleccionar supermercados por Zona -----------------------------------------------------------------------
        public async Task<MostrarSupermercadosVM> GetSupermercadosAsync(string zona,string nombre) { 
     

            List<Supermercado> supermercados = await _context.Supermercado.Include(x => x.Zona).ToListAsync();

            // Si no filtro por ninguna zona o la zona es nula

            if (String.IsNullOrEmpty(zona) && String.IsNullOrEmpty(nombre))
            {
                MostrarSupermercadosVM msvm = new MostrarSupermercadosVM
                {
                    Supermercados = supermercados,
                    Zonas = await _context.Zona.ToListAsync()
                };
                return (msvm);
            }

            // Filtro que busca los supermercados por el nombre de la empresa . Ejemplo : Mercadona, Eroski

            if (!String.IsNullOrEmpty(nombre))
            {
                supermercados = supermercados.Where(x => x.Empresa.ToLower()
                                .Contains(nombre.ToLower())).ToList();
            }

            // Si he seleccionado el nombre de la zona filtro por ese nombre de zona y me devuelve eso

            if (!String.IsNullOrEmpty(zona))
            {
                supermercados = supermercados.Where(x => x.Zona.Nombre == zona).ToList();
            }


            MostrarSupermercadosVM msvm2 = new MostrarSupermercadosVM
            {
                Supermercados = supermercados,
                Zonas = await _context.Zona.ToListAsync()
            };
            return (msvm2);

        }

      

        //----------------------------------------------------------------------------------------------------------------------

        public bool SupermercadoExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateSupermercadoAsync(Supermercado supermercado)
        {
             _context.Update(supermercado);
              await _context.SaveChangesAsync();
        }

 
    }
}
