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
    public class departamentoController : Controller
    {
        private readonly hospitalDbContext _context;

        public departamentoController(hospitalDbContext context)
        {
            _context = context;
        }

        // GET: departamento
        public async Task<IActionResult> Index()
        {
              return _context.departamento != null ? 
                          View(await _context.departamento.ToListAsync()) :
                          Problem("Entity set 'hospitalDbContext.departamento'  is null.");
        }

        // GET: departamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.departamento
                .FirstOrDefaultAsync(m => m.iddepartamento == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: departamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: departamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iddepartamento,nombredepartamento")] departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        // GET: departamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        // POST: departamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iddepartamento,nombredepartamento")] departamento departamento)
        {
            if (id != departamento.iddepartamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departamentoExists(departamento.iddepartamento))
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
            return View(departamento);
        }

        // GET: departamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.departamento
                .FirstOrDefaultAsync(m => m.iddepartamento == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.departamento == null)
            {
                return Problem("Entity set 'hospitalDbContext.departamento'  is null.");
            }
            var departamento = await _context.departamento.FindAsync(id);
            if (departamento != null)
            {
                _context.departamento.Remove(departamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool departamentoExists(int id)
        {
          return (_context.departamento?.Any(e => e.iddepartamento == id)).GetValueOrDefault();
        }
    }
}
