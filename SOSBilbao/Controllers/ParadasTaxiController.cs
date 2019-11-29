using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOSBilbao.Data;
using SOSBilbao.Models;
using SOSBilbao.Models.ViewModels;
using SOSBilbao.Services;

namespace SOSBilbao.Controllers
{
    public class ParadasTaxiController : Controller
    {
        private readonly IParadaTaxi _paradasTaxiServices;

        public ParadasTaxiController(IParadaTaxi paradasTaxiServices)
        {
            _paradasTaxiServices = paradasTaxiServices;
        }

        public async Task<IActionResult> Index(string zona,string nombre)
        {
            return View(await _paradasTaxiServices.GetParadaTaxiAsync(zona,nombre));
        }



        // Vista Detalle Supermercado------------------------------------------------------------------------
        // GET: Supermercados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paradaTaxi = await _paradasTaxiServices.GetParadaTaxiByIdAsync(id);

            if (paradaTaxi == null)
            {
                return NotFound();
            }

            return View(paradaTaxi);
        }


        //--------------------------------------------------------------------------------------------------------------------------

        [Authorize(Roles = "administrador")]

        // GET: Supermercados/Create
        public IActionResult Create()
        {
            return View();
        }



        // POST: Supermercados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Direccion,Zona,Imagen,Latitud,Longitud")] ParadaTaxi paradaTaxi)
        {
            if (ModelState.IsValid)
            {
                await _paradasTaxiServices.CreateParadaTaxiAsync(paradaTaxi);
                return RedirectToAction(nameof(Index));
            }
            return View(paradaTaxi);
        }

        // GET: Supermercados/Edit/5-----------------------------------------------------------------------------------------
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paradaTaxi = await _paradasTaxiServices.GetParadaTaxiByIdAsync(id);
            if (paradaTaxi == null)
            {
                return NotFound();
            }
            return View(paradaTaxi);
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Authorize(Roles = "administrador")]

        // POST: Supermercados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Direccion,Zona,Imagen,Latitud,Longitud")] ParadaTaxi paradaTaxi)
        {
            if (id != paradaTaxi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _paradasTaxiServices.UpdateParadaTaxiAsync(paradaTaxi);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_paradasTaxiServices.ParadaTaxiExists(paradaTaxi.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paradaTaxi);
        }

        [Authorize(Roles = "administrador")]

        // GET: Supermercados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paradaTaxi = await _paradasTaxiServices.GetParadaTaxiByIdAsync(id);

            if (paradaTaxi== null)
            {
                return NotFound();
            }

            return View(paradaTaxi);
        }

        [Authorize(Roles = "administrador")]
        // POST: Supermercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paradaTaxi = await _paradasTaxiServices.GetParadaTaxiByIdAsync(id);
            await _paradasTaxiServices.DeleteParadaTaxiAsync(paradaTaxi);
            return RedirectToAction(nameof(Index));
        }

        //private bool SupermercadoExists(int id)
        //{
        //    return _context.Supermercado.Any(e => e.Id == id);
        //}
    }
}

