using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2020GG602_2020SM602_2020ML601.Models;

namespace P2_2020GG602_2020SM602_2020ML601.Controllers
{
    public class generosController : Controller
    {
        private readonly hospitalDbContext _context;

        public generosController(hospitalDbContext context)
        {
            _context = context;
        }

        // GET: generos
        public async Task<IActionResult> Index()
        {
              return _context.generos != null ? 
                          View(await _context.generos.ToListAsync()) :
                          Problem("Entity set 'hospitalDbContext.generos'  is null.");
        }

        // GET: generos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.generos == null)
            {
                return NotFound();
            }

            var generos = await _context.generos
                .FirstOrDefaultAsync(m => m.idgenero == id);
            if (generos == null)
            {
                return NotFound();
            }

            return View(generos);
        }

        // GET: generos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: generos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idgenero,generotipo")] generos generos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generos);
        }

        // GET: generos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.generos == null)
            {
                return NotFound();
            }

            var generos = await _context.generos.FindAsync(id);
            if (generos == null)
            {
                return NotFound();
            }
            return View(generos);
        }

        // POST: generos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idgenero,generotipo")] generos generos)
        {
            if (id != generos.idgenero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!generosExists(generos.idgenero))
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
            return View(generos);
        }

        // GET: generos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.generos == null)
            {
                return NotFound();
            }

            var generos = await _context.generos
                .FirstOrDefaultAsync(m => m.idgenero == id);
            if (generos == null)
            {
                return NotFound();
            }

            return View(generos);
        }

        // POST: generos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.generos == null)
            {
                return Problem("Entity set 'hospitalDbContext.generos'  is null.");
            }
            var generos = await _context.generos.FindAsync(id);
            if (generos != null)
            {
                _context.generos.Remove(generos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool generosExists(int id)
        {
          return (_context.generos?.Any(e => e.idgenero == id)).GetValueOrDefault();
        }
    }
}
