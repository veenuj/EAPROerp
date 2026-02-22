using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EaproERP.Data;
using EaproERP.Models;
using EaproERP.Services;

namespace EaproERP.Controllers
{
    public class TrustController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrustController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- NEW: MAIN LEDGER VIEW ---
        // Route: /Trust
        public async Task<IActionResult> Index()
        {
            var ledger = await _context.TrustLedger
                .OrderByDescending(b => b.Index) // Show newest blocks first
                .ToListAsync();

            return View(ledger);
        }

        // GET: Trust/Timeline/SERIAL_NUMBER
        public async Task<IActionResult> Timeline(string id)
        {
            var history = await _context.TrustLedger
                .Where(b => b.ProductId == id)
                .OrderBy(b => b.Index)
                .ToListAsync();

            ViewBag.ProductId = id;
            return View(history);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(string productId, string eventDescription)
        {
            var lastBlock = await _context.TrustLedger
                .OrderByDescending(b => b.Index)
                .FirstOrDefaultAsync();
            
            var newBlock = new TrustBlock {
                Index = (lastBlock?.Index ?? 0) + 1,
                Timestamp = DateTime.Now,
                ProductId = productId,
                Data = eventDescription,
                PreviousHash = lastBlock?.Hash ?? "0" 
            };

            newBlock.Hash = TrustEngine.CalculateHash(
                newBlock.Index, 
                newBlock.Timestamp, 
                newBlock.Data, 
                newBlock.PreviousHash
            );
            
            _context.TrustLedger.Add(newBlock);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Timeline), new { id = productId });
        }

        // --- THE NEURAL AUDIT ---
        // Checks if anyone manually edited the SQL database
        public async Task<IActionResult> VerifyChain()
        {
            var blocks = await _context.TrustLedger.OrderBy(b => b.Index).ToListAsync();
            bool isChainValid = true;

            for (int i = 1; i < blocks.Count; i++)
            {
                var currentBlock = blocks[i];
                var previousBlock = blocks[i - 1];

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    isChainValid = false;
                    break;
                }

                string recalculatedHash = TrustEngine.CalculateHash(
                    currentBlock.Index, currentBlock.Timestamp, currentBlock.Data, currentBlock.PreviousHash);
                    
                if (currentBlock.Hash != recalculatedHash)
                {
                    isChainValid = false;
                    break;
                }
            }

            ViewBag.IsValid = isChainValid;
            return View("AuditStatus", blocks);
        }
    }
}