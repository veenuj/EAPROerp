using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EaproERP.Data;
using EaproERP.Models;

namespace EaproERP.Controllers
{
    public class ProcurementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcurementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Procurement
        public async Task<IActionResult> Index()
        {
            var vendors = await _context.Vendors.ToListAsync();

            // 🛑 DEBUG/MOCK DATA: If database is empty, show sample vendors for UI testing
            if (!vendors.Any())
            {
                vendors = new List<Vendor>
                {
                    new Vendor { Id = 1, CompanyName = "Silicon Tech Japan", Category = "Raw Materials", ContactPerson = "Kenji Sato", OutstandingBalance = 4500000, ReliabilityScore = 98, Status = "Active" },
                    new Vendor { Id = 2, CompanyName = "Delta Logistics Hub", Category = "Logistics", ContactPerson = "Amit Sharma", OutstandingBalance = 120000, ReliabilityScore = 82, Status = "Active" },
                    new Vendor { Id = 3, CompanyName = "Global Circuits Ltd", Category = "Electronics", ContactPerson = "Sarah Chen", OutstandingBalance = 890000, ReliabilityScore = 45, Status = "Under Review" }
                };
            }

            return View(vendors);
        }

        // GET: Procurement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procurement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyName,Category,ContactPerson,Email,OutstandingBalance,ReliabilityScore,Status")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }

        // GET: Procurement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null) return NotFound();
            
            return View(vendor);
        }

        // POST: Procurement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Category,ContactPerson,Email,OutstandingBalance,ReliabilityScore,Status")] Vendor vendor)
        {
            if (id != vendor.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(vendor.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }

        private bool VendorExists(int id)
        {
            return _context.Vendors.Any(e => e.Id == id);
        }
    }
}