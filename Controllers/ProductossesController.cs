using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using productospra3.Models;

namespace productospra3.Controllers
{
    public class ProductossesController : Controller
    {
        private readonly BdproductosContext _context;

        public ProductossesController(BdproductosContext context)
        {
            _context = context;
        }

        // GET: Productosses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productosses.ToListAsync());
        }

        // GET: Productosses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoss = await _context.Productosses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productoss == null)
            {
                return NotFound();
            }

            return View(productoss);
        }

        // GET: Productosses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productosses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio")] Productoss productoss)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productoss);
        }

        // GET: Productosses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoss = await _context.Productosses.FindAsync(id);
            if (productoss == null)
            {
                return NotFound();
            }
            return View(productoss);
        }

        // POST: Productosses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio")] Productoss productoss)
        {
            if (id != productoss.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductossExists(productoss.Id))
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
            return View(productoss);
        }

        // GET: Productosses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoss = await _context.Productosses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productoss == null)
            {
                return NotFound();
            }

            return View(productoss);
        }

        // POST: Productosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoss = await _context.Productosses.FindAsync(id);
            if (productoss != null)
            {
                _context.Productosses.Remove(productoss);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductossExists(int id)
        {
            return _context.Productosses.Any(e => e.Id == id);
        }
    }
}
