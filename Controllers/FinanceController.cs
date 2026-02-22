using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EaproERP.Data;
using EaproERP.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EaproERP.Controllers
{
    public class FinanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FinanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult CreateInvoice()
        {
            return View(new Invoice());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateInvoice(Invoice invoice)
        {
            ModelState.Remove("InvoiceNumber");
            ModelState.Remove("Status");

            if (ModelState.IsValid)
            {
                var count = await _context.Invoices.CountAsync();
                invoice.InvoiceNumber = $"EAP/FIN/{DateTime.Now.Year}/{(count + 1):D3}";
                invoice.Status = "Unpaid";

                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(InvoiceList));
            }

            return View("CreateInvoice", invoice);
        }

        public async Task<IActionResult> InvoiceList()
        {
            var invoices = await _context.Invoices
                .OrderByDescending(i => i.BillingDate)
                .ToListAsync();
            return View(invoices);
        }
        
        public async Task<IActionResult> Pay(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null) return NotFound();
            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessPayment(int id, string paymentMethod, string transactionId)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                invoice.Status = "Paid";
                invoice.PaymentMethod = paymentMethod;
                invoice.TransactionId = transactionId;
                invoice.PaymentDate = DateTime.Now;

                _context.Update(invoice);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(InvoiceList));
        }

        // --- UPDATED: PASSWORD PROTECTED SUMMARY ---
        public async Task<IActionResult> PaymentSummary(string pin)
        {
            const string MASTER_PIN = "1234"; 
            const int MAX_ATTEMPTS = 3;
            const int LOCKOUT_MINUTES = 10;

            // 1. Check if user is currently locked out
            var lockoutTimeStr = HttpContext.Session.GetString("LockoutExpiry");
            if (!string.IsNullOrEmpty(lockoutTimeStr))
            {
                var expiry = DateTime.Parse(lockoutTimeStr);
                if (DateTime.Now < expiry)
                {
                    ViewBag.LockoutExpiry = expiry.ToString("o"); // ISO format for JS
                    return View("SecurityLock");
                }
                else
                {
                    // Lockout expired, reset attempts
                    HttpContext.Session.Remove("LockoutExpiry");
                    HttpContext.Session.SetInt32("FailedAttempts", 0);
                }
            }

            // 2. Initial visit (no PIN entered yet)
            if (string.IsNullOrEmpty(pin))
            {
                return View("SecurityLock");
            }

            // 3. Validate PIN
            if (pin == MASTER_PIN)
            {
                // Success: Reset failures and show data
                HttpContext.Session.SetInt32("FailedAttempts", 0);
                var records = await _context.Invoices.OrderByDescending(i => i.BillingDate).ToListAsync();
                return View(records);
            }
            else
            {
                // Failure: Increment counter
                int attempts = (HttpContext.Session.GetInt32("FailedAttempts") ?? 0) + 1;
                HttpContext.Session.SetInt32("FailedAttempts", attempts);

                if (attempts >= MAX_ATTEMPTS)
                {
                    // Trigger 10-minute lockout
                    var expiry = DateTime.Now.AddMinutes(LOCKOUT_MINUTES);
                    HttpContext.Session.SetString("LockoutExpiry", expiry.ToString());
                    ViewBag.LockoutExpiry = expiry.ToString("o");
                }

                ViewBag.ErrorMessage = $"Invalid PIN. Attempt {attempts} of {MAX_ATTEMPTS}";
                return View("SecurityLock");
            }
        }
    }
}