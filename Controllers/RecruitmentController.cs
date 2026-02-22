using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Linq;
using EaproERP.Data;
using EaproERP.Models;

namespace EaproERP.Controllers
{
    public class RecruitmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public RecruitmentController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Recruitment/Pipeline
        public async Task<IActionResult> Pipeline()
        {
            var activeCandidates = await _context.Candidates
                .Where(c => c.Status == "Active")
                .ToListAsync();
            return View(activeCandidates);
        }

        // POST: Advance Step
        [HttpPost]
        public async Task<IActionResult> Advance(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null && candidate.CurrentStep < 5)
            {
                candidate.CurrentStep++;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Pipeline));
        }

        // POST: Finalize Hire
        [HttpPost]
        public async Task<IActionResult> FinalizeHire(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                candidate.Status = "Hired"; 
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(CandidateArchive));
        }

        // GET: Recruitment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recruitment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidate candidate, IFormFile? resumeFile)
        {
            ModelState.Remove("Status");
            ModelState.Remove("ResumeUrl");

            if (ModelState.IsValid)
            {
                candidate.Status = "Active";

                if (resumeFile != null && resumeFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "resumes");
                    
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(resumeFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await resumeFile.CopyToAsync(fileStream);
                    }

                    candidate.ResumeUrl = "/uploads/resumes/" + uniqueFileName;
                }
                else if (string.IsNullOrEmpty(candidate.ResumeUrl))
                {
                    candidate.ResumeUrl = "";
                }

                _context.Candidates.Add(candidate);
                await _context.SaveChangesAsync();
                
                TempData["SuccessMessage"] = "Candidate Sourced Successfully!";
                
                return RedirectToAction(nameof(Pipeline));
            }
            
            return View(candidate);
        }

        // GET: Recruitment/CandidateArchive
        public async Task<IActionResult> CandidateArchive()
        {
            var allCandidates = await _context.Candidates
                .OrderByDescending(c => c.AppliedDate)
                .ToListAsync();
            return View(allCandidates);
        }

        // GET: Recruitment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null) return NotFound();

            return View(candidate);
        }

        // POST: Update HR Notes
        [HttpPost]
        public async Task<IActionResult> UpdateNotes(int id, string notes)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                // 🛑 TITAN UPGRADE: Fully activated note saving!
                candidate.Notes = notes; 
                await _context.SaveChangesAsync();
                
                // Triggers the Premium SweetAlert on reload
                TempData["SuccessMessage"] = "HR Intelligence Log Updated!";
            }
            return RedirectToAction(nameof(Details), new { id = id });
        }

        // POST: Reject Candidate
        [HttpPost]
        public async Task<IActionResult> RejectCandidate(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                candidate.Status = "Rejected"; 
                await _context.SaveChangesAsync();
                
                // Triggers the Premium SweetAlert on reload
                TempData["SuccessMessage"] = "Candidate has been rejected and archived.";
            }
            
            // Kick them back to the active pipeline view where the candidate will now be hidden
            return RedirectToAction(nameof(Pipeline)); 
        }
    }
}