using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaPrestamos.Data;
using SistemaPrestamos.Models;

namespace SistemaPrestamos.Controllers
{
    public class RecibosCobroController : Controller
    {
        private readonly SistemaPrestamosDbContext _context;

        public RecibosCobroController(SistemaPrestamosDbContext context)
        {
            _context = context;
        }

        // GET: ReciboCobroes
        public async Task<IActionResult> Index()
        {
            var sistemaPrestamosDbContext = _context.RecibosCobro.Include(r => r.Cliente).Include(r => r.Prestamo);
            return View(await sistemaPrestamosDbContext.ToListAsync());
        }

        // GET: ReciboCobroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciboCobro = await _context.RecibosCobro
                .Include(r => r.Cliente)
                .Include(r => r.Prestamo)
                .FirstOrDefaultAsync(m => m.ReciboCobroId == id);
            if (reciboCobro == null)
            {
                return NotFound();
            }

            return View(reciboCobro);
        }

        // GET: ReciboCobroes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido");
            ViewData["PrestamoId"] = new SelectList(_context.Prestamos, "PrestamoId", "Estado");
            return View();
        }

        // POST: ReciboCobroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReciboCobroId,PrestamoId,ClienteId,FechaPago,MontoPagado,MontoCapital,MontoInteres,MontoMora,SaldoAnterior,SaldoActual,MetodoPago,NumeroTransaccion,Notas")] ReciboCobro reciboCobro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reciboCobro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido", reciboCobro.ClienteId);
            ViewData["PrestamoId"] = new SelectList(_context.Prestamos, "PrestamoId", "Estado", reciboCobro.PrestamoId);
            return View(reciboCobro);
        }

        // GET: ReciboCobroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciboCobro = await _context.RecibosCobro.FindAsync(id);
            if (reciboCobro == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido", reciboCobro.ClienteId);
            ViewData["PrestamoId"] = new SelectList(_context.Prestamos, "PrestamoId", "Estado", reciboCobro.PrestamoId);
            return View(reciboCobro);
        }

        // POST: ReciboCobroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReciboCobroId,PrestamoId,ClienteId,FechaPago,MontoPagado,MontoCapital,MontoInteres,MontoMora,SaldoAnterior,SaldoActual,MetodoPago,NumeroTransaccion,Notas")] ReciboCobro reciboCobro)
        {
            if (id != reciboCobro.ReciboCobroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reciboCobro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReciboCobroExists(reciboCobro.ReciboCobroId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido", reciboCobro.ClienteId);
            ViewData["PrestamoId"] = new SelectList(_context.Prestamos, "PrestamoId", "Estado", reciboCobro.PrestamoId);
            return View(reciboCobro);
        }

        // GET: ReciboCobroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciboCobro = await _context.RecibosCobro
                .Include(r => r.Cliente)
                .Include(r => r.Prestamo)
                .FirstOrDefaultAsync(m => m.ReciboCobroId == id);
            if (reciboCobro == null)
            {
                return NotFound();
            }

            return View(reciboCobro);
        }

        // POST: ReciboCobroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reciboCobro = await _context.RecibosCobro.FindAsync(id);
            if (reciboCobro != null)
            {
                _context.RecibosCobro.Remove(reciboCobro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReciboCobroExists(int id)
        {
            return _context.RecibosCobro.Any(e => e.ReciboCobroId == id);
        }
    }
}
