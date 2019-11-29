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
    public class SupermercadosController : Controller
    {
        private readonly ISupermercados _supermercadosServices;

        public SupermercadosController(ISupermercados supermercadoServices)
        {
            _supermercadosServices = supermercadoServices;
        }


       public async Task<IActionResult> Index(string zona, string nombre)
        {
            //ViewData["hora"] = await _supermercadosServices.DiferenciaHoraActualHoraCierre
            return View(await _supermercadosServices.GetSupermercadosAsync(zona,nombre));
        }



        // Vista Detalle Supermercado------------------------------------------------------------------------
        // GET: Supermercados/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var supermercado = await _supermercadosServices.GetSupermercadoByIdAsync(id);

                if (supermercado == null)
                {
                    return NotFound();
                }

                return View(supermercado);
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
        public async Task<IActionResult> Create([Bind("Id,Empresa,Direccion,Zona,Telefono,HoraApertura,HoraCierre")] Supermercado supermercado)
        {
            if (ModelState.IsValid)
            {
                await _supermercadosServices.CreateSupermercadoAsync(supermercado);
                return RedirectToAction(nameof(Index));
            }
            return View(supermercado);
        }

        // GET: Supermercados/Edit/5-----------------------------------------------------------------------------------------
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supermercado = await _supermercadosServices.GetSupermercadoByIdAsync(id);
            if (supermercado == null)
            {
                return NotFound();
            }
            return View(supermercado);
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Authorize(Roles = "administrador")]

        // POST: Supermercados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Empresa,Direccion,Zona,Telefono,HoraApertura,HoraCierre")] Supermercado supermercado)
        {
            if (id != supermercado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _supermercadosServices.UpdateSupermercadoAsync(supermercado);
                 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_supermercadosServices.SupermercadoExists(supermercado.Id))
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
            return View(supermercado);
        }

        [Authorize(Roles = "administrador")]

        // GET: Supermercados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supermercado = await _supermercadosServices.GetSupermercadoByIdAsync(id);
              
            if (supermercado == null)
            {
                return NotFound();
            }

            return View(supermercado);
        }

        [Authorize(Roles = "administrador")]
        // POST: Supermercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supermercado = await _supermercadosServices.GetSupermercadoByIdAsync(id);
            await _supermercadosServices.DeleteSupermercadoAsync(supermercado);
            return RedirectToAction(nameof(Index));
        }


        //public async Task<IActionResult> DiferenciaHoraActualHoraCierre(Supermercado supermercado) 
     
        //    return View(await _supermercadosServices;
        //}

        //private bool SupermercadoExists(int id)
        //{
        //    return _context.Supermercado.Any(e => e.Id == id);
        //}
    }
}
