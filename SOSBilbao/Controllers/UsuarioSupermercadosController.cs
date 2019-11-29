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
    public class UsuarioSupermercadosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioSupermercadosController(ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UsuarioSupermercados

        // Este metodo viene revotado del "Guardar Favoritos" que esta justo debajo. Ha sido necesario crear la tabla de UsuarioSupermercado
        // para poder aplicar la logica de filtrado.
        public async Task<IActionResult> Index(string favoritoSupermercado)
        {
            ViewData["favoritoSupermercado"] = favoritoSupermercado;

            Usuario usuario = await _userManager.GetUserAsync(User);

            List<UsuarioSupermercado> supermercadosfavoritos = await _context.UsuarioSupermercado.Include(x => x.Supermercado).Include(x => x.Usuario).Where(x => x.UsuarioId == usuario.Id).ToListAsync();

            return View(supermercadosfavoritos);
        }


        public async Task<IActionResult> GuardarFavorito(int id)
        {

            Usuario usuario = await _userManager.GetUserAsync(User);
            Supermercado supermercado = await _context.Supermercado.FindAsync(id);

            UsuarioSupermercado existeusuariosupermercado = _context.UsuarioSupermercado.FirstOrDefault(x => x.IdSupermercado == id);



            // Si el "Favorito" no existe se crea el favorito
            if (existeusuariosupermercado == null)
            {
                UsuarioSupermercado supermercadoFavorito = new UsuarioSupermercado
                {
                    Usuario = usuario,
                    Supermercado = supermercado
                };
                if (ModelState.IsValid)
                {
                    _context.Add(supermercadoFavorito);
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
                return RedirectToAction("Index", new { favoritoSupermercado = "existe" });

            }
        }

        // GET: UsuarioSupermercados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioSupermercado = await _context.UsuarioSupermercado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioSupermercado == null)
            {
                return NotFound();
            }

            return View(usuarioSupermercado);
        }

        // GET: UsuarioSupermercados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioSupermercados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] UsuarioSupermercado usuarioSupermercado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioSupermercado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioSupermercado);
        }

        // GET: UsuarioSupermercados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioSupermercado = await _context.UsuarioSupermercado.FindAsync(id);
            if (usuarioSupermercado == null)
            {
                return NotFound();
            }
            return View(usuarioSupermercado);
        }

        // POST: UsuarioSupermercados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] UsuarioSupermercado usuarioSupermercado)
        {
            if (id != usuarioSupermercado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioSupermercado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioSupermercadoExists(usuarioSupermercado.Id))
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
            return View(usuarioSupermercado);
        }

        // GET: UsuarioSupermercados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioSupermercado = await _context.UsuarioSupermercado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioSupermercado == null)
            {
                return NotFound();
            }

            return View(usuarioSupermercado);
        }

        // POST: UsuarioSupermercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioSupermercado = await _context.UsuarioSupermercado.FindAsync(id);
            _context.UsuarioSupermercado.Remove(usuarioSupermercado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioSupermercadoExists(int id)
        {
            return _context.UsuarioSupermercado.Any(e => e.Id == id);
        }
    }
}
