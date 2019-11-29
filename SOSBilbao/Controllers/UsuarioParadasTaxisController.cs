using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOSBilbao.Data;
using SOSBilbao.Models;

namespace SOSBilbao.Controllers
{
    public class UsuarioParadasTaxisController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioParadasTaxisController(ApplicationDbContext context,UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UsuarioParadasTaxis
        public async Task<IActionResult> Index(string favoritoParada)

        {
            ViewData["favoritoParada"] = favoritoParada;

            Usuario usuario = await _userManager.GetUserAsync(User);
            List<UsuarioParadasTaxi> paradastaxifavoritas = await _context.UsuarioParadasTaxi.Include(x => x.ParadaTaxi).Include(x => x.Usuario).Where(x => x.UsuarioId == usuario.Id).ToListAsync();
            return View(await _context.UsuarioParadasTaxi.ToListAsync());
        }

        public async Task<IActionResult> GuardarFavorito(int id)
        {
            // Metodo para "Guardar Favoritos"
            // Funciona de la siguiente manera
            //1: Coges el usuario de la sesion  
            //2. Coges la farmacia con el id que te viene por parametro y buscar la farmacia asociada
            // 3. Incluyes los dos parametros en el objeto farmacia. El id de esta tabla es autogenerado por eso no lo tienes que incluir
            // 4. Por ultimo realizamos el RedirectToAction para que lo pase a la vista

            Usuario usuario = await _userManager.GetUserAsync(User);
            ParadaTaxi paradaTaxi = await _context.ParadaTaxi.FindAsync(id);


            UsuarioParadasTaxi existeusuarioparadastaxi = _context.UsuarioParadasTaxi.FirstOrDefault(x => x.ParadaTaxiId== id);

            // Si el "Favorito" no existe se crea el favorito
            if (existeusuarioparadastaxi == null)
            { 
                UsuarioParadasTaxi usuarioParadaTaxi = new UsuarioParadasTaxi
                {
                Usuario = usuario,
                ParadaTaxi = paradaTaxi
                };

                if (ModelState.IsValid)
                {
                    _context.Add(usuarioParadaTaxi);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {

                // Si el favorito existe este se pasa como FAVORITO = TRUE al INDEX
                return RedirectToAction("Index", new { favoritoParada = "existe" });

            }
        }


        // GET: UsuarioParadasTaxis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioParadasTaxi = await _context.UsuarioParadasTaxi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioParadasTaxi == null)
            {
                return NotFound();
            }

            return View(usuarioParadasTaxi);
        }

        // GET: UsuarioParadasTaxis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioParadasTaxis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] UsuarioParadasTaxi usuarioParadasTaxi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioParadasTaxi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioParadasTaxi);
        }

        // GET: UsuarioParadasTaxis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioParadasTaxi = await _context.UsuarioParadasTaxi.FindAsync(id);
            if (usuarioParadasTaxi == null)
            {
                return NotFound();
            }
            return View(usuarioParadasTaxi);
        }

        // POST: UsuarioParadasTaxis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] UsuarioParadasTaxi usuarioParadasTaxi)
        {
            if (id != usuarioParadasTaxi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioParadasTaxi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioParadasTaxiExists(usuarioParadasTaxi.Id))
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
            return View(usuarioParadasTaxi);
        }

        // GET: UsuarioParadasTaxis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioParadasTaxi = await _context.UsuarioParadasTaxi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioParadasTaxi == null)
            {
                return NotFound();
            }

            return View(usuarioParadasTaxi);
        }

        // POST: UsuarioParadasTaxis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioParadasTaxi = await _context.UsuarioParadasTaxi.FindAsync(id);
            _context.UsuarioParadasTaxi.Remove(usuarioParadasTaxi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioParadasTaxiExists(int id)
        {
            return _context.UsuarioParadasTaxi.Any(e => e.Id == id);
        }
    }
}
