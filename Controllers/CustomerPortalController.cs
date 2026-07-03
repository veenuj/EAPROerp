using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using EaproERP.Data;
using EaproERP.Models;

namespace EaproERP.Controllers
{
    public class CustomerPortalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerPortalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- PUBLIC FACING CUSTOMER PORTAL ---

        // GET: /CustomerPortal/
        public IActionResult Index()
        {
            return View();
        }

        // POST: /CustomerPortal/SubmitTicket
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitTicket(CustomerTicket ticket)
        {
            ModelState.Remove("Status");

            if (ModelState.IsValid)
            {
                _context.CustomerTickets.Add(ticket);
                await _context.SaveChangesAsync();
                
                TempData["SuccessMessage"] = $"Your {ticket.RequestType} request (Ticket #{ticket.Id}) has been successfully logged. Our team will contact you shortly.";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Please fill in all required fields.";
            return View("Index", ticket);
        }

        // --- INTERNAL ADMIN DASHBOARD ---

        // GET: /CustomerPortal/AdminDashboard
        public async Task<IActionResult> AdminDashboard()
        {
            // Fetch all tickets, newest first
            var tickets = await _context.CustomerTickets
                                        .OrderByDescending(t => t.CreatedAt)
                                        .ToListAsync();
            return View(tickets);
        }

        // POST: /CustomerPortal/ResolveTicket
        [HttpPost]
        public async Task<IActionResult> ResolveTicket(int id)
        {
            var ticket = await _context.CustomerTickets.FindAsync(id);
            if (ticket != null)
            {
                ticket.Status = "Resolved";
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Ticket #{ticket.Id} marked as Resolved.";
            }
            return RedirectToAction(nameof(AdminDashboard));
        }
    }
}