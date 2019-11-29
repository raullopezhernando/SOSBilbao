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
    public class FarmaciasController : Controller
    {
        private readonly IFarmacia _farmaciaServices;
    

        public FarmaciasController(IFarmacia farmaciaServices)
        {
            _farmaciaServices = farmaciaServices;
          
        }

        
        public async Task<IActionResult> Index(string zona,string nombre)
        {
            return View(await _farmaciaServices.GetFarmaciaAsync(zona,nombre));
        }



        // Vista Detalle Farmacia------------------------------------------------------------------------
        // GET: Farmacias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacia = await _farmaciaServices.GetFarmaciaByIdAsync(id);

            if ( farmacia== null)
            {
                return NotFound();
            }

            return View(farmacia);
        }
        

        //--------------------------------------------------------------------------------------------------------------------------

        [Authorize(Roles = "administrador")]

        // GET: Farmacias/Create
        public IActionResult Create()
        {
            return View();
        }



        // POST: Farmacias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Telefono,HorarioAperturaMañana,HorarioCierreMañana,HorarioAperturaTarde,HorarioCierreTarde,ZonaId,Longitud,Latitud,Imagen")] Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                await _farmaciaServices.CreateFarmaciaAsync(farmacia);
                return RedirectToAction(nameof(Index));
            }
            return View(farmacia);
        }

        // GET: Farmacias/Edit/5-----------------------------------------------------------------------------------------
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacia = await _farmaciaServices.GetFarmaciaByIdAsync(id);
            if (farmacia == null)
            {
                return NotFound();
            }
            return View(farmacia);
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Authorize(Roles = "administrador")]

        // POST: Farmacias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Telefono,HorarioAperturaMañana,HorarioCierreMañana,HorarioAperturaTarde,HorarioCierreTarde,ZonaId,Longitud,Latitud,Imagen")] Farmacia farmacia)
        {
            if (id != farmacia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _farmaciaServices.UpdateFarmaciaAsync(farmacia);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_farmaciaServices.FarmaciaExists(farmacia.Id))
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
            return View(farmacia);
        }

        [Authorize(Roles = "administrador")]

        // GET: Farmacias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacia = await _farmaciaServices.GetFarmaciaByIdAsync(id);

            if (farmacia == null)
            {
                return NotFound();
            }

            return View(farmacia);
        }

        [Authorize(Roles = "administrador")]
        // POST: Supermercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmacia = await _farmaciaServices.GetFarmaciaByIdAsync(id);
            await _farmaciaServices.DeleteFarmaciaAsync(farmacia);
            return RedirectToAction(nameof(Index));
        }

    }
}
