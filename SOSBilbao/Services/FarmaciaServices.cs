using Microsoft.EntityFrameworkCore;
using SOSBilbao.Data;
using SOSBilbao.Models;
using SOSBilbao.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Services
{
    public class FarmaciaServices : IFarmacia
    {
        private readonly ApplicationDbContext _context;

        public FarmaciaServices(ApplicationDbContext context)
        {
            _context = context;
        }


        // SERVICE "CREAR FARMACIA" ---------------------------
        public async Task CreateFarmaciaAsync(Farmacia farmacia)
        {
            await _context.AddAsync(farmacia);
            await _context.SaveChangesAsync();
        }

        //-------------------------------------------------------------------


        // SERVICE "ELIMINAR FARMACIA"-------------------------------------
        public async Task DeleteFarmaciaAsync(Farmacia farmacia)
        {
            _context.Farmacia.Remove(farmacia);

            await _context.SaveChangesAsync();
        }


        // SERVICES "FARMACIA EXISTE" NO IMPLEMENTADO 
        public bool FarmaciaExists(int id)
        {
            return _context.Zona.Any(e => e.Id == id);
        }

        //----------------------------------------------------------------


        // SERVICES " SELECCIONAR FARMACIA POR ZONA " 

        public async Task<MostrarFarmaciasVM> GetFarmaciaAsync(string zona,string nombre)
        {
            List<Farmacia> farmacias = await _context.Farmacia.Include(x => x.Zona).ToListAsync();

            // Si no filtro por ninguna zona o la zona es nula

            if (String.IsNullOrEmpty(zona) && String.IsNullOrEmpty(nombre))
            {
                MostrarFarmaciasVM mfvm = new MostrarFarmaciasVM
                {
                    Farmacias = farmacias,
                    Zonas = await _context.Zona.ToListAsync()
                };
                return (mfvm);
            }

            if (!String.IsNullOrEmpty(nombre))
            {
                farmacias = farmacias.Where(x => x.Nombre.ToLower()
                                .Contains(nombre.ToLower())).ToList();
            }


            // Si he seleccionado el nombre de la zona filtro por esa zona y me devuelve eso

            if (!String.IsNullOrEmpty(zona))
            {
                farmacias = farmacias.Where(x => x.Zona.Nombre == zona).ToList();
            }


            MostrarFarmaciasVM mfvm2 = new MostrarFarmaciasVM
            {
                Farmacias = farmacias,
                Zonas = await _context.Zona.ToListAsync()
            };
            return (mfvm2);

        }

        // -----------------------------------------------------------------------------------


        // SERVICES "ENCONTRAR FARMACIA POR ID"--------------------------------------------
        public async Task<Farmacia> GetFarmaciaByIdAsync(int? id)
        {
            return await _context.Farmacia.FindAsync(id);
        }

        //----------------------------------------------------------------------------------

        // SERVICE "ACTUALIZAR FARMACIA POR ID "------------------------------------------
        public async Task UpdateFarmaciaAsync(Farmacia farmacia)
        {
            _context.Update(farmacia);
            await _context.SaveChangesAsync();
        }

        //--------------------------------------------------------------------------------

        //SERVICE "EDITAR FARMACIA"


    }
}
