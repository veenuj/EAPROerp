using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EaproERP.Data;

namespace EaproERP.Controllers
{
    public class StoreLocatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoreLocatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /StoreLocator
        public async Task<IActionResult> Index()
        {
            var stores = await _context.StoreLocations.ToListAsync();
            return View(stores);
        }
    }
}