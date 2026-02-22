using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EaproERP.Models;
using EaproERP.Agents;
using EaproERP.Data;
using Microsoft.AspNetCore.Http; // Added for Session support

namespace EaproERP.Controllers
{
    public class PayrollController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PayrollController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🛑 SECURITY GATEKEEPER: Checks if the Payroll Vault is unlocked
        private bool IsAuthorized() => HttpContext.Session.GetString("PayrollAuth") == "Authorized";

        // --- AUTHENTICATION ACTIONS ---

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string password)
        {
            // 🔒 SECURITY KEY: Change this to your preferred master password
            if (password == "admin") 
            {
                HttpContext.Session.SetString("PayrollAuth", "Authorized");
                return RedirectToAction(nameof(Index));
            }
            
            TempData["Error"] = "Invalid Security Key. Access Denied.";
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("PayrollAuth");
            return RedirectToAction(nameof(Login));
        }

        // --- AUTHORIZED MANAGEMENT ACTIONS ---

        public async Task<IActionResult> Index()
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));

            var employees = await _context.Employees.ToListAsync();
            foreach (var emp in employees)
            {
                AiEngine.RunPayrollAgent(emp);
            }
            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));

            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();
            
            AiEngine.RunPayrollAgent(emp);
            return View(emp);
        }

        // 🛑 NEW: RECRUITMENT TO PAYROLL BRIDGE 🛑
        // GET: /Payroll/OnboardCandidate?candidateId=5
        public async Task<IActionResult> OnboardCandidate(int candidateId)
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));

            // 1. Find the Candidate in the Recruitment DB
            var candidate = await _context.Candidates.FindAsync(candidateId);
            if (candidate == null) return NotFound();

            // 2. Officially mark them as Hired so they archive correctly
            candidate.Status = "Hired";
            candidate.CurrentStep = 5;
            await _context.SaveChangesAsync();

            // 3. Auto-Map to a new Employee Object
            var newEmployee = new Employee
            {
                Name = candidate.Name,
                // If you have fields like Email or Role in your Employee model, uncomment these:
                // Email = candidate.Email,
                // Role = candidate.Position,
            };

            // 4. Send success signal
            TempData["SuccessMessage"] = $"Offer logged! Please configure payroll details for {candidate.Name}.";
            
            // 5. Load the Create Employee view with the pre-filled data
            return View("Create", newEmployee);
        }

        public IActionResult Create() 
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));

            if (ModelState.IsValid)
            {
                AiEngine.RunPayrollAgent(emp);
                _context.Employees.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));

            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));

            if (ModelState.IsValid)
            {
                _context.Update(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));

            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));

            var emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: /Payroll/Disburse
        public async Task<IActionResult> Disburse()
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));

            var today = DateTime.Today;
            var currentMonth = today.ToString("MMMM yyyy");
            
            var paidEmployeeIds = await _context.SalaryDisbursements
                .Where(d => d.MonthYear == currentMonth)
                .Select(d => d.EmployeeId)
                .ToListAsync();

            var allEmployees = await _context.Employees.ToListAsync();
            var pendingList = new List<PayrollViewModel>();
            var firstDay = new DateTime(today.Year, today.Month, 1);

            foreach (var emp in allEmployees.Where(e => !paidEmployeeIds.Contains(e.Id)))
            {
                int days = await _context.AttendanceRecords.CountAsync(a => a.EmployeeId == emp.Id && a.Date >= firstDay);
                decimal net = ((emp.BaseSalary / 26) * days) + (emp.Bonus ?? 0m);
                pendingList.Add(new PayrollViewModel { Employee = emp, DaysPresent = days, NetPay = net, Month = currentMonth });
            }

            var history = await _context.SalaryDisbursements
                .Include(d => d.Employee)
                .Where(d => d.MonthYear == currentMonth)
                .OrderByDescending(d => d.DisbursedOn)
                .ToListAsync();

            ViewBag.History = history;
            return View(pendingList);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmPayment(int empId, decimal amount, int days, string month)
        {
            if (!IsAuthorized()) return Json(new { success = false, message = "Unauthorized Access" });

            var disbursement = new SalaryDisbursement {
                EmployeeId = empId,
                NetPayout = amount,
                DaysPresent = days,
                MonthYear = month,
                DisbursedOn = DateTime.Now,
                TransactionId = "EAP-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper()
            };

            _context.SalaryDisbursements.Add(disbursement);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        // --- PUBLIC ACCESS ACTIONS (Kiosk & Mobile) ---

        public IActionResult AttendanceKiosk() => View();

        public async Task<IActionResult> AttendanceLogs()
        {
            if (!IsAuthorized()) return RedirectToAction(nameof(Login));

            var logs = await _context.AttendanceRecords
                .Include(a => a.Employee) 
                .OrderByDescending(a => a.Date)
                .ThenByDescending(a => a.PunchInTime)
                .ToListAsync();

            return View(logs);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPunch([FromBody] PunchRequest request)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeCode == request.Barcode);
            if (emp == null) return Json(new { success = false, message = "Employee not found." });

            var today = DateTime.Today;
            var record = await _context.AttendanceRecords
                .FirstOrDefaultAsync(a => a.EmployeeId == emp.Id && a.Date == today);

            var timeNow = DateTime.Now.TimeOfDay;

            if (record == null)
            {
                record = new AttendanceRecord
                {
                    EmployeeId = emp.Id,
                    Date = today,
                    PunchInTime = timeNow,
                    Status = timeNow.Hours >= 10 ? "Late" : "On Time"
                };
                _context.AttendanceRecords.Add(record);
                await _context.SaveChangesAsync();
                return Json(new { success = true, action = "PUNCH IN", name = emp.Name, time = timeNow.ToString(@"hh\:mm") });
            }
            else if (record.PunchOutTime == null)
            {
                record.PunchOutTime = timeNow;
                _context.Update(record);
                await _context.SaveChangesAsync();
                return Json(new { success = true, action = "PUNCH OUT", name = emp.Name, time = timeNow.ToString(@"hh\:mm") });
            }

            return Json(new { success = false, message = $"{emp.Name} has already punched out today." });
        }

        public class PunchRequest { public string Barcode { get; set; } = string.Empty; }

        [HttpPost]
        public async Task<IActionResult> SaveBiometric(int id, string rawId, string publicKey)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();

            emp.BiometricCredentialId = Convert.FromBase64String(rawId);
            emp.BiometricPublicKey = Convert.FromBase64String(publicKey);

            await _context.SaveChangesAsync();
            return Ok();
        }

        private static readonly Dictionary<string, string> AuthSessions = new Dictionary<string, string>();

        public IActionResult MobileAuth(string token)
        {
            ViewBag.Token = token;
            return View();
        }

        [HttpPost]
        public IActionResult VerifyMobile(string token, string empCode)
        {
            AuthSessions[token] = empCode;
            return Ok(new { success = true });
        }

        [HttpGet]
        public IActionResult CheckMobileStatus(string token)
        {
            if (AuthSessions.ContainsKey(token))
            {
                var empCode = AuthSessions[token];
                AuthSessions.Remove(token);
                return Json(new { verified = true, employeeCode = empCode });
            }
            return Json(new { verified = false });
        }
    }
}