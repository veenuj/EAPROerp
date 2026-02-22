using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EaproERP.Models;
using EaproERP.Agents;
using EaproERP.Data;

namespace EaproERP.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Inject the Database through the constructor
        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ
        public async Task<IActionResult> Index()
        {
            var inventory = await _context.Inventory.ToListAsync();
            foreach(var product in inventory)
            {
                AiEngine.RunInventoryAgent(product);
            }
            return View(inventory);
        }

        // CREATE (GET)
        public IActionResult Create() => View();

        // CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                AiEngine.RunInventoryAgent(product);
                _context.Inventory.Add(product);
                await _context.SaveChangesAsync(); // Saves to MS SQL
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // EDIT (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Inventory.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // EDIT (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // DELETE (GET)
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Inventory.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Inventory.FindAsync(id);
            if (product != null)
            {
                _context.Inventory.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Inventory.FindAsync(id);
            if (product == null) return NotFound();
            
            AiEngine.RunInventoryAgent(product);
            return View(product);
        }
    }
}