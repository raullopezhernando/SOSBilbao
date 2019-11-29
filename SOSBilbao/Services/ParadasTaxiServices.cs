using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SOSBilbao.Data;
using SOSBilbao.Models;
using SOSBilbao.Models.ViewModels;

namespace SOSBilbao.Services
{
    public class ParadasTaxiServices : IParadaTaxi
    {
        private readonly ApplicationDbContext _context;

        public ParadasTaxiServices(ApplicationDbContext context)
        {
            _context = context;
        }


        // SERVICES "CREAR PARADA TAXI"
        public Task CreateParadaTaxiAsync(ParadaTaxi paradaTaxi)
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------------------

        // SERVICE "BORRAR PARADA TAXI"
        public async Task DeleteParadaTaxiAsync(ParadaTaxi paradaTaxi)
        {
            _context.ParadaTaxi.Remove(paradaTaxi);

            await _context.SaveChangesAsync();
        }

        //--------------------------------------------------------------------------------------------------

       
        // SERVICE  SELECCIONAR PARADA TAXI POR ID "--------------------------------------------------
        public async Task<ParadaTaxi> GetParadaTaxiByIdAsync(int? id)
        {
            return await _context.ParadaTaxi.FindAsync(id);
        }

        //--------------------------------------------------------------------------------

        // SERVICE NO IMPLEMENTADO---------------------------------------------------------


        public bool ParadaTaxiExists(int id)
        {
            throw new NotImplementedException();
        }

        //---------------------------------------------------------------------------------

        // SERVICE PARA " ACTUALIZAR PARADAS DE TAXI "
        public async Task UpdateParadaTaxiAsync(ParadaTaxi paradaTaxi)
        {
            _context.Update(paradaTaxi);
            await _context.SaveChangesAsync();
        }

        //-----------------------------------------------------------------------------------


        // Seleccionar ParadaTaxi por Zona -----------------------------------------------------------------------
        public async Task<MostrarParadasTaxiVM> GetParadaTaxiAsync(string zona, string nombre)
        {


            List<ParadaTaxi> paradaTaxis = await _context.ParadaTaxi.Include(x => x.Zona).ToListAsync();

            // Si no filtro por ninguna zona o la zona es nula

            if (String.IsNullOrEmpty(zona) && String.IsNullOrEmpty(nombre))
            {
                MostrarParadasTaxiVM msvm = new MostrarParadasTaxiVM
                {
                    ParadaTaxis = paradaTaxis,
                    Zonas = await _context.Zona.ToListAsync()
                };
                return (msvm);
            }

            // Si se ha introducido la busqueda por el nombre mostrar aquellas paradas de taxi que coincidan con el nombre
            if (!String.IsNullOrEmpty(nombre))
            {
                paradaTaxis = paradaTaxis.Where(x => x.Direccion.ToLower()
                                .Contains(nombre.ToLower())).ToList();
            }

            // Si he seleccionado el nombre de la zona filtro por ese nombre y me devuelve eso

            if (!String.IsNullOrEmpty(zona))
            {
                paradaTaxis = paradaTaxis.Where(x => x.Zona.Nombre == zona).ToList();
            }


            MostrarParadasTaxiVM msvm2 = new MostrarParadasTaxiVM
            {
                ParadaTaxis = paradaTaxis,
                Zonas = await _context.Zona.ToListAsync()
            };
            return (msvm2);

        }



        //----------------------------------------------------------------------------------------------------------------------
    }
}
