using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EaproERP.Data;
using EaproERP.Models;

namespace EaproERP.Controllers
{
    public class ProductionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // VIEW: Live Dashboard
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductionLines.ToListAsync());
        }

        // CREATE: GET (Boot New Line)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductionLine productionLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productionLine);
        }

        // EDIT: GET (Calibrate Line)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var productionLine = await _context.ProductionLines.FindAsync(id);
            if (productionLine == null) return NotFound();
            return View(productionLine);
        }

        // EDIT: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductionLine productionLine)
        {
            if (id != productionLine.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(productionLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productionLine);
        }

        // DELETE: POST (Shut Down Line)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionLine = await _context.ProductionLines.FindAsync(id);
            if (productionLine != null)
            {
                _context.ProductionLines.Remove(productionLine);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}