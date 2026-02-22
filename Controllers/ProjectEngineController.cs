using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EaproERP.Data;
using EaproERP.Models;

namespace EaproERP.Controllers
{
    public class ProjectEngineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectEngineController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var projects = await _context.ProjectEngines.ToListAsync();
            
            // Mock Data for UI Handshake
            if (!projects.Any()) {
                projects = new List<ProjectEngine> {
                    new ProjectEngine { Id = 1, ProjectName = "Meerut Smart City Hub", ClientName = "UP Govt", SystemCapacityKW = 450.0, CurrentPhase = "Installation", ExecutionProgress = 65, SiteLocation = "Meerut, UP" },
                    new ProjectEngine { Id = 2, ProjectName = "Roorkee Hospital Solar", ClientName = "Health Dept", SystemCapacityKW = 120.5, CurrentPhase = "Site Survey", ExecutionProgress = 15, SiteLocation = "Roorkee, UK" }
                };
            }
            return View(projects);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectEngine project)
        {
            if (ModelState.IsValid) {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }
    }
}