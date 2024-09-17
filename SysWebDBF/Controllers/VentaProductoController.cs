using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysWebDBF.Models;

namespace SysWebDBF.Controllers
{
    public class VentaProductoController : Controller
    {
        private readonly BDContext _context;

        public VentaProductoController(BDContext context)
        {
            _context = context;
        }

        // GET: VentaProducto
        public async Task<IActionResult> Index()
        {
            var bDContext = _context.VentaProducto.Include(v => v.IdProductoNavigation).Include(v => v.IdVentaNavigation);
            return View(await bDContext.ToListAsync());
        }

        // GET: VentaProducto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VentaProducto == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProducto
                .Include(v => v.IdProductoNavigation)
                .Include(v => v.IdVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ventaProducto == null)
            {
                return NotFound();
            }

            return View(ventaProducto);
        }

        // GET: VentaProducto/Create
        public IActionResult Create()
        {
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre");
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta");
            return View();
        }

        // POST: VentaProducto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,IdProducto,Cantidad")] VentaProducto ventaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", ventaProducto.IdProducto);
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", ventaProducto.IdVenta);
            return View(ventaProducto);
        }

        // GET: VentaProducto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VentaProducto == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProducto.FindAsync(id);
            if (ventaProducto == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", ventaProducto.IdProducto);
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", ventaProducto.IdVenta);
            return View(ventaProducto);
        }

        // POST: VentaProducto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,IdProducto,Cantidad")] VentaProducto ventaProducto)
        {
            if (id != ventaProducto.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaProductoExists(ventaProducto.IdVenta))
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
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "IdProducto", ventaProducto.IdProducto);
            ViewData["IdVenta"] = new SelectList(_context.Venta, "IdVenta", "IdVenta", ventaProducto.IdVenta);
            return View(ventaProducto);
        }

        // GET: VentaProducto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VentaProducto == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProducto
                .Include(v => v.IdProductoNavigation)
                .Include(v => v.IdVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (ventaProducto == null)
            {
                return NotFound();
            }

            return View(ventaProducto);
        }

        // POST: VentaProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VentaProducto == null)
            {
                return Problem("Entity set 'BDContext.VentaProducto'  is null.");
            }
            var ventaProducto = await _context.VentaProducto.FindAsync(id);
            if (ventaProducto != null)
            {
                _context.VentaProducto.Remove(ventaProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaProductoExists(int id)
        {
          return (_context.VentaProducto?.Any(e => e.IdVenta == id)).GetValueOrDefault();
        }
    }
}
