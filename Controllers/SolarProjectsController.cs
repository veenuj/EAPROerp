using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EaproERP.Data;
using EaproERP.Models;

namespace EaproERP.Controllers
{
    public class SolarProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SolarProjectsController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.SolarProjects.ToListAsync());

        public async Task<IActionResult> Details(int id)
        {
            var project = await _context.SolarProjects.FindAsync(id);
            return project == null ? NotFound() : View(project);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SolarProject project)
        {
            if (ModelState.IsValid) {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var project = await _context.SolarProjects.FindAsync(id);
            return project == null ? NotFound() : View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SolarProject project)
        {
            if (id != project.Id) return NotFound();
            if (ModelState.IsValid) {
                _context.Update(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.SolarProjects.FindAsync(id);
            return project == null ? NotFound() : View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.SolarProjects.FindAsync(id);
            if (project != null) _context.SolarProjects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}