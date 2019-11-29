using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOSBilbao.Data;
using SOSBilbao.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOSBilbao.Controllers
{
    public class UsuarioFarmaciasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;


        public UsuarioFarmaciasController(ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;


        }

        // GET: UsuarioFarmacias
        public async Task<IActionResult> Index(string favorito)
        {
            ViewData["favorito"] = favorito; 
        

           Usuario usuario = await _userManager.GetUserAsync(User);

            List<UsuarioFarmacia> farmaciafavoritos = await _context.UsuarioFarmacia.Include(x => x.Farmacia).Include(x => x.Usuario).Where(x => x.UsuarioId == usuario.Id).ToListAsync();

            return View(farmaciafavoritos);

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
            Farmacia farmacia = await _context.Farmacia.FindAsync(id);

            UsuarioFarmacia existeusuariofarmacia =  _context.UsuarioFarmacia.FirstOrDefault(x => x.FarmaciaId == id);

            // Si el "Favorito" no existe se crea el favorito
            if (existeusuariofarmacia == null)
            {


                UsuarioFarmacia usuarioFarmacia = new UsuarioFarmacia
                {
                    Usuario = usuario,
                    Farmacia = farmacia
                };
                if (ModelState.IsValid)
                {
                    _context.Add(usuarioFarmacia);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
                //_context.Add(usuarioFarmacia);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

            }
            else
            {

               // Si el favorito existe este se pasa como FAVORITO = TRUE al INDEX
                return RedirectToAction("Index", new { favorito = "existe"});

            }
        }

        // GET: UsuarioFarmacias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioFarmacia = await _context.UsuarioFarmacia
                .Include(u => u.Farmacia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioFarmacia == null)
            {
                return NotFound();
            }

            return View(usuarioFarmacia);
        }

        // GET: UsuarioFarmacias/Create
        public IActionResult Create()
        {
            ViewData["FarmaciaId"] = new SelectList(_context.Farmacia, "Id", "Id");
            return View();
        }

        // POST: UsuarioFarmacias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,FarmaciaId")] UsuarioFarmacia usuarioFarmacia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioFarmacia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmaciaId"] = new SelectList(_context.Farmacia, "Id", "Id", usuarioFarmacia.FarmaciaId);
            return View(usuarioFarmacia);
        }

        // GET: UsuarioFarmacias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioFarmacia = await _context.UsuarioFarmacia.FindAsync(id);
            if (usuarioFarmacia == null)
            {
                return NotFound();
            }
            ViewData["FarmaciaId"] = new SelectList(_context.Farmacia, "Id", "Id", usuarioFarmacia.FarmaciaId);
            return View(usuarioFarmacia);
        }

        // POST: UsuarioFarmacias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,FarmaciaId")] UsuarioFarmacia usuarioFarmacia)
        {
            if (id != usuarioFarmacia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioFarmacia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioFarmaciaExists(usuarioFarmacia.Id))
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
            ViewData["FarmaciaId"] = new SelectList(_context.Farmacia, "Id", "Id", usuarioFarmacia.FarmaciaId);
            return View(usuarioFarmacia);
        }

        // GET: UsuarioFarmacias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioFarmacia = await _context.UsuarioFarmacia
                .Include(u => u.Farmacia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioFarmacia == null)
            {
                return NotFound();
            }

            return View(usuarioFarmacia);
        }

        // POST: UsuarioFarmacias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioFarmacia = await _context.UsuarioFarmacia.FindAsync(id);
            _context.UsuarioFarmacia.Remove(usuarioFarmacia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioFarmaciaExists(int id)
        {
            return _context.UsuarioFarmacia.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Favorito(int id)
        {
            // Creacion de favorito de usuario farmacia
            UsuarioFarmacia favorito = new UsuarioFarmacia
            {
                // Recogemos el usuario que se ha logeado
                Usuario = await _userManager.GetUserAsync(User),
                // Id de la farmacia proveniente de farmacia
                FarmaciaId = id

            };

            // Añadimos el favorito a la tabla de UsuarioFarmacia
            await _context.AddAsync(favorito);
            // Salvamos los cambios
            await _context.SaveChangesAsync();
            // Redirigimos el favorito a la vista de UsuarioFarmacia (Favoritos Farmacia)
            return RedirectToAction("Index");
        }
    }
}
