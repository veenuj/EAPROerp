using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EaproERP.Models;
using EaproERP.Data;

namespace EaproERP.Controllers
{
    public class ServiceHubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceHubController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceHub
        // This pulls real data from the database for the main dashboard
        public async Task<IActionResult> Index()
        {
            var warranties = await _context.Warranties.ToListAsync();
            var amcContracts = await _context.AmcContracts.ToListAsync();

            var viewModel = new ServiceDashboardViewModel
            {
                Warranties = warranties,
                AmcContracts = amcContracts
            };

            return View(viewModel);
        }

        // --- WARRANTY NODE ACTIONS ---

        [HttpGet]
        public IActionResult CreateWarranty()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWarranty(WarrantyNode warranty)
        {
            if (ModelState.IsValid)
            {
                _context.Warranties.Add(warranty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(warranty);
        }

        // --- AMC NODE ACTIONS ---

        [HttpGet]
        public IActionResult CreateAmc()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAmc(AmcNode amc)
        {
            if (ModelState.IsValid)
            {
                _context.AmcContracts.Add(amc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amc);
        }
    }

    // ViewModel to pass multiple lists to the Index view
    public class ServiceDashboardViewModel
    {
        public List<WarrantyNode> Warranties { get; set; } = new();
        public List<AmcNode> AmcContracts { get; set; } = new();
    }
}