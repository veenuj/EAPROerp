using Microsoft.EntityFrameworkCore;
using EaproERP.Models;

namespace EaproERP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Inventory { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SolarProject> SolarProjects { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<ProductionLine> ProductionLines { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<SalaryDisbursement> SalaryDisbursements { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<ProjectEngine> ProjectEngines { get; set; }
        public DbSet<WarrantyNode> Warranties { get; set; }
        public DbSet<AmcNode> AmcContracts { get; set; }
        public DbSet<TrustBlock> TrustLedger { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- PRECISION & COLUMN CONFIGURATION ---
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Employee>().Property(e => e.BaseSalary).HasPrecision(18, 2);
            modelBuilder.Entity<Employee>().Property(e => e.Bonus).HasPrecision(18, 2);
            modelBuilder.Entity<ProductionLine>().Property(p => p.QualityScore).HasPrecision(5, 2);
            modelBuilder.Entity<Vendor>().Property(v => v.OutstandingBalance).HasPrecision(18, 2);
            modelBuilder.Entity<ProjectEngine>().Property(p => p.ContractValue).HasPrecision(18, 2);
            modelBuilder.Entity<AmcNode>().Property(a => a.ContractValue).HasPrecision(18, 2);
            modelBuilder.Entity<Dealer>().Property(d => d.AnnualTurnover).HasPrecision(18, 2);

            modelBuilder.Entity<SalaryDisbursement>(entity =>
            {
                entity.Property(e => e.CalculatedGross).HasColumnType("decimal(18,2)");
                entity.Property(e => e.BonusAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.NetPayout).HasColumnType("decimal(18,2)");
            });

            // --- SEED DATA: INVENTORY ---
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "EAPRO TRON-3200 3000VA 24V AI-MPPT Dual Battery PCU", Category = "Inverter", StockLevel = 45, Price = 19349m, AIStockPrediction = "" },
                new Product { Id = 2, Name = "EAPRO 3500VA 48V MPPT Single Phase Pure Sine Wave", Category = "Inverter", StockLevel = 18, Price = 31570m, AIStockPrediction = "" },
                new Product { Id = 5, Name = "EAPRO 590W TOPCon Bifacial Solar Panel", Category = "Solar Panel", StockLevel = 120, Price = 18500m, AIStockPrediction = "" },
                new Product { Id = 9, Name = "EAPRO Enerbatt 250Ah Solar Battery", Category = "Battery", StockLevel = 60, Price = 16500m, AIStockPrediction = "" }
            );

            // --- SEED DATA: EMPLOYEES ---
            modelBuilder.Entity<Employee>().HasData(
                new Employee { 
                    Id = 101, Name = "Amit Sharma", Department = "Manufacturing", Designation = "Plant Supervisor", 
                    BaseSalary = 45000, Bonus = 5000, EmployeeCode = "EAP-2301-1001", DateOfJoining = new DateTime(2023, 1, 15),
                    Email = "amit.sharma@eapro.in", Phone = "+91-9876543210", GovernmentId = "ABCDE1234F"
                },
                new Employee { 
                    Id = 102, Name = "Priya Singh", Department = "R&D", Designation = "DSP Solar Engineer", 
                    BaseSalary = 85000, Bonus = 18000, EmployeeCode = "EAP-2305-1002", DateOfJoining = new DateTime(2023, 5, 20),
                    Email = "priya.singh@eapro.in", Phone = "+91-8765432109", GovernmentId = "456789012345"
                }
            );

            // --- SEED DATA: DEALER NETWORK ---
            modelBuilder.Entity<Dealer>().HasData(
                new Dealer { Id = 1, BusinessName = "North Solar Hub Meerut", Region = "North", ContactPerson = "Vikas Gupta", Tier = "Platinum", AnnualTurnover = 12500000, IsServiceCenter = true },
                new Dealer { Id = 2, BusinessName = "Roorkee Energy Solutions", Region = "North", ContactPerson = "Anil Tyagi", Tier = "Gold", AnnualTurnover = 8500000, IsServiceCenter = true },
                new Dealer { Id = 3, BusinessName = "Delhi Solar Power Systems", Region = "North", ContactPerson = "Sandeep Malhotra", Tier = "Platinum", AnnualTurnover = 25000000, IsServiceCenter = false },
                new Dealer { Id = 4, BusinessName = "Southern Energy Chennai", Region = "South", ContactPerson = "K. Ramakrishnan", Tier = "Silver", AnnualTurnover = 4500000, IsServiceCenter = true },
                new Dealer { Id = 5, BusinessName = "Western Solar Pune", Region = "West", ContactPerson = "Rahul Deshmukh", Tier = "Gold", AnnualTurnover = 9800000, IsServiceCenter = false }
            );

            // --- SEED DATA: PRODUCTION LINES ---
            modelBuilder.Entity<ProductionLine>().HasData(
                new ProductionLine { Id = 1, LineName = "Line Alpha-1", CurrentProduct = "TRON-3200 AI-MPPT", DailyTarget = 250, UnitsCompleted = 180, Status = "Active", QualityScore = 99.5m },
                new ProductionLine { Id = 2, LineName = "Line Beta-Sigma", CurrentProduct = "590W TOPCon Bifacial", DailyTarget = 500, UnitsCompleted = 410, Status = "Active", QualityScore = 98.8m }
            );

            // --- SEED DATA: PROCUREMENT (VENDORS) ---
            modelBuilder.Entity<Vendor>().HasData(
                new Vendor { Id = 1, CompanyName = "Silicon Tech Japan", Category = "Electronics", ContactPerson = "Kenji Sato", Email = "sato@silicontech.jp", OutstandingBalance = 4500000, ReliabilityScore = 98, Status = "Active" },
                new Vendor { Id = 2, CompanyName = "Delta Logistics Meerut", Category = "Logistics", ContactPerson = "Vikas Tyagi", Email = "v.tyagi@deltalog.in", OutstandingBalance = 125000, ReliabilityScore = 85, Status = "Active" }
            );

            // --- SEED DATA: PROJECT ENGINE ---
            modelBuilder.Entity<ProjectEngine>().HasData(
                new ProjectEngine { Id = 1, ProjectName = "Roorkee Medical College Solar Hub", ClientName = "UP Health Dept", SiteLocation = "Roorkee, UK", SystemCapacityKW = 450.0, ProjectType = "On-Grid", ExecutionProgress = 65, CurrentPhase = "Installation", ContractValue = 12500000 },
                new ProjectEngine { Id = 2, ProjectName = "Meerut IT Park Unit 4", ClientName = "Smart City Auth", SiteLocation = "Meerut, UP", SystemCapacityKW = 120.5, ProjectType = "Hybrid", ExecutionProgress = 15, CurrentPhase = "Site Survey", ContractValue = 4200000 }
            );

            // --- SEED DATA: SERVICE HUB (WARRANTY & AMC) ---
            modelBuilder.Entity<WarrantyNode>().HasData(
                new WarrantyNode { Id = 1, SerialNumber = "TRON-3200-S04-001", CustomerName = "Anuj Dhiman", ProductName = "Tron 3200 PCU", PurchaseDate = new DateTime(2025, 8, 10), WarrantyPeriodMonths = 24, IsRegistered = true }
            );

            modelBuilder.Entity<AmcNode>().HasData(
                new AmcNode { Id = 1, ClientName = "Pacific Mall Dehradun", ProjectSite = "Main Roof B", ContractStartDate = new DateTime(2026, 1, 1), ContractExpiryDate = new DateTime(2027, 1, 1), ContractValue = 120000, ServiceFrequency = "Quarterly", NextScheduledService = new DateTime(2026, 4, 1) }
            );

            // --- SEED DATA: BLOCKCHAIN TRUST LEDGER ---
            modelBuilder.Entity<TrustBlock>().HasData(
                new TrustBlock { Index = 1, Timestamp = new DateTime(2026, 2, 20, 10, 0, 0), ProductId = "TRON-3200-S04-001", Data = "GENESIS: Manufacturing Started (Roorkee Unit 4)", PreviousHash = "0", Hash = "816E2247E11695CBA365930039E1C2E1" },
                new TrustBlock { Index = 2, Timestamp = new DateTime(2026, 2, 20, 14, 30, 0), ProductId = "TRON-3200-S04-001", Data = "QC Passed: Pure Sine Wave Efficiency 98.5%", PreviousHash = "816E2247E11695CBA365930039E1C2E1", Hash = "2C8C3886A26B5061B465228D7017A44F" }
            );

            // --- SEED DATA: TALENT PIPELINE (NEW CANDIDATES) ---
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate { Id = 1, Name = "Rahul Verma", Email = "rahul.v@gmail.com", Position = "GenAI Developer", CurrentStep = 1, Status = "Active", AppliedDate = new DateTime(2026, 2, 10) },
                new Candidate { Id = 2, Name = "Sneha Kapoor", Email = "sneha.k@eapro.in", Position = "Supply Chain Manager", CurrentStep = 3, Status = "Active", AppliedDate = new DateTime(2026, 2, 12) },
                new Candidate { Id = 3, Name = "Vikram Aditya", Email = "aditya.v@outlook.com", Position = "Embedded Systems Engineer", CurrentStep = 4, Status = "Active", AppliedDate = new DateTime(2026, 2, 15) },
                new Candidate { Id = 4, Name = "Pooja Hegde", Email = "pooja.h@gmail.com", Position = "Technical Sales Executive", CurrentStep = 5, Status = "Active", AppliedDate = new DateTime(2026, 2, 18) }
            );
        }
    }
}