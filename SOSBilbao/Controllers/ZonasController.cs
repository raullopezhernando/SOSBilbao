using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOSBilbao.Data;
using SOSBilbao.Models;
using SOSBilbao.Services;

namespace SOSBilbao.Controllers
{
    public class ZonasController : Controller
    {
        private readonly IZonas _zonasServices;

        public ZonasController(IZonas zonasServices)
        {
            _zonasServices = zonasServices;
        }

        // GET: Zonas
        public async Task<IActionResult> Index()
        {
            return View(await _zonasServices.GetZonasAsync());
        }

        // GET: Zonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zona = await _zonasServices.GetZonaByIdAsync(id);
            if (zona == null)
            {
                return NotFound();
            }

            return View(zona);
        }

        // GET: Zonas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zonas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                await _zonasServices.CreateZonaAsync(zona);
                return RedirectToAction(nameof(Index));
            }
            return View(zona);
        }

        // GET: Zonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zona = await _zonasServices.GetZonaByIdAsync(id);
            if (zona == null)
            {
                return NotFound();
            }
            return View(zona);
        }

        // POST: Zonas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Zona zona)
        {
            if (id != zona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _zonasServices.UpdateZonaAsync(zona);
                
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_zonasServices.ZonaExists(zona.Id))
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
            return View(zona);
        }

        // GET: Zonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zona = await _zonasServices.GetZonaByIdAsync(id);
               
            if (zona == null)
            {
                return NotFound();
            }

            return View(zona);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zona = await _zonasServices.GetZonaByIdAsync(id);

            await _zonasServices.DeleteZonaAsync(zona);

            return RedirectToAction(nameof(Index));
        }

        //private bool ZonaExists(int id)
        //{
        //    return _zonasServices.Zona.Any(e => e.Id == id);
        //}
    }
}
