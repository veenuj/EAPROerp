using Microsoft.EntityFrameworkCore;
using EaproERP.Models;
using System;

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
        public DbSet<CustomerTicket> CustomerTickets { get; set; }
       public DbSet<StoreLocation> StoreLocations { get; set; } 

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

            // --- SEED DATA: CUSTOMER TICKETS (NEW) ---
            modelBuilder.Entity<CustomerTicket>().HasData(
                new CustomerTicket { Id = 1, RequestType = "Complaint", CustomerName = "Rakesh Tiwari", PhoneNumber = "+91-9876512345", Email = "rakesh.t@gmail.com", ProductSerialNumber = "TRON-3200-S04-005", Description = "Inverter is showing error code E-04 during power cut.", Status = "Open", CreatedAt = new DateTime(2026, 2, 20, 10, 30, 0) },
                new CustomerTicket { Id = 2, RequestType = "Installation", CustomerName = "Meera Joshi", PhoneNumber = "+91-8765423456", Email = "meera.j@yahoo.com", ProductSerialNumber = "EAPRO-590W-PANEL-SET", Description = "Need installation for 5KW solar panels at my residence in Dehradun.", Status = "Resolved", CreatedAt = new DateTime(2026, 2, 18, 14, 15, 0) },
                new CustomerTicket { Id = 3, RequestType = "Product Registration", CustomerName = "Suresh Kumar", PhoneNumber = "+91-7654334567", Email = "suresh.k@outlook.com", ProductSerialNumber = "ENERBATT-250AH-001", Description = "Registering newly purchased battery for standard 5-year warranty.", Status = "Open", CreatedAt = new DateTime(2026, 2, 21, 9, 45, 0) }
            );
            // --- SEED DATA: EAPRO STORE LOCATOR ---
            // --- SEED DATA: EAPRO STORE LOCATOR (LIVE DEALER NETWORK) ---
            modelBuilder.Entity<StoreLocation>().HasData(
                new StoreLocation { Id = 1, DealerName = "GENSTAR AGROVET FARMS", ContactPerson = "Srikant Dubey", Mobile = "9935200038", Address = "Sarojini Nagar, Amausi", City = "Lucknow", State = "Uttar Pradesh", Pincode = "226008" },
                new StoreLocation { Id = 2, DealerName = "Power tech Electronics", ContactPerson = "Thanigai Malai", Mobile = "9789586737", Address = "No 8 Tholkappiyar street Arcot, Anna silai", City = "Vellore", State = "Tamil Nadu", Pincode = "632503" },
                new StoreLocation { Id = 3, DealerName = "Inspire Energy care", ContactPerson = "KARTHIGAIVENI", Mobile = "9940652303", Address = "7, BRINDHA GARDEN, SASTRY NAGAR, VAIKKAMEDU", City = "Erode", State = "Tamil Nadu", Pincode = "638002" },
                new StoreLocation { Id = 4, DealerName = "STAR ELECTRICAL", ContactPerson = "PERUMAL SATHEESH KUMAR", Mobile = "9698903550", Address = "4/5, POOTTAI MAIN ROAD", City = "Kallakkurichi", State = "Tamil Nadu", Pincode = "606401" },
                new StoreLocation { Id = 5, DealerName = "WARRIOR POWER SYSTEM S", ContactPerson = "MR.P.SRINIVASAN", Mobile = "7200281000", Address = "NO 15, WARRIOR HOUSE, BHARATHIDASAN STREET, TEACHERS COLONY", City = "Erode", State = "Tamil Nadu", Pincode = "638011" },
                new StoreLocation { Id = 6, DealerName = "VINT ENTERPRISES", ContactPerson = "Thomas", Mobile = "8807191615", Address = "121 othavada Street kodapakkm, Avm", City = "Chennai", State = "Tamil Nadu", Pincode = "600024" },
                new StoreLocation { Id = 7, DealerName = "Thirumal Enterprises", ContactPerson = "Mr. ganesh kumar", Mobile = "9840191279", Address = "Konnur high road, 5th St, railway quarters, Ayanavaram", City = "Chennai", State = "Tamil Nadu", Pincode = "600023" },
                new StoreLocation { Id = 8, DealerName = "TED VAAA GLOBAL ENTERPRISE", ContactPerson = "MR. PARTHASARATHI PERUMAL KANNIAPPAN", Mobile = "9442233383", Address = "BUILDING NO. 17, 1ST MAIN STREET, MVM NAGAR", City = "Dindigul", State = "Tamil Nadu", Pincode = "624004" },
                new StoreLocation { Id = 9, DealerName = "SUN TRADERS", ContactPerson = "GEORGEMARIAARPUTHAM GEORGEFERNANDO", Mobile = "8122434145", Address = "Joseph convent complex, opp Joseph convent", City = "Kanyakumari", State = "Tamil Nadu", Pincode = "629001" },
                new StoreLocation { Id = 10, DealerName = "SSM BATTERIES", ContactPerson = "NITHYA GURUMOORTHY", Mobile = "9865884748", Address = "S.F. NO. 308/1B1A, NITHYA, TIRUCHENGODE ROAD, PALLIPALAYAM", City = "Namakkal", State = "Tamil Nadu", Pincode = "638006" },
                new StoreLocation { Id = 11, DealerName = "PRAKASH GREEN ENERGY", ContactPerson = "MR. SELVAPRAKASH MURUGESAN", Mobile = "9994901500", Address = "no 14 konar street jaihindpuram", City = "Madurai", State = "Tamil Nadu", Pincode = "625011" },
                new StoreLocation { Id = 12, DealerName = "POWER HOUSE", ContactPerson = "Jagathes", Mobile = "9962869007", Address = "no-1 9 th Lane 1 St cross street Adayar, sastri nagar", City = "Chennai", State = "Tamil Nadu", Pincode = "620020" },
                new StoreLocation { Id = 13, DealerName = "OMEGA DIGITAL SYSTEMS", ContactPerson = "SUBHASHREE", Mobile = "9667891576", Address = "NO 1/105, 52ND STREET, 7TH AVENUE, ASHOK NAGAR", City = "Chennai", State = "Tamil Nadu", Pincode = "600083" },
                new StoreLocation { Id = 14, DealerName = "MSM TAMIL TRADERS", ContactPerson = "R MUTHUSELVI", Mobile = "6369922811", Address = "3/188-A, MAIN ROAD, POOLANGULAM, ALANGULAM", City = "Tirunelveli", State = "Tamil Nadu", Pincode = "627415" },
                new StoreLocation { Id = 15, DealerName = "MICRO BATTERY HOUSE", ContactPerson = "KARIYAPPA SIDDANNAN VEERABADRAN", Mobile = "9943905073", Address = "395/1A1, CHENNAI BYE PASS HIGH WAY CIRCLE, NEAR SBI ATM", City = "Krishnagiri", State = "Tamil Nadu", Pincode = "635001" },
                new StoreLocation { Id = 16, DealerName = "LIGHTNING POWER CONTROL", ContactPerson = "SELVA KUMAR", Mobile = "9843438701", Address = "PLOT NO 23, VEERAIYA STREET, KUNDUPALAYAM, THATTANCHAVADY", City = "Pondicherry", State = "Puducherry", Pincode = "605009" },
                new StoreLocation { Id = 17, DealerName = "JEYAS SOLAR AND POWER SERVICE", ContactPerson = "JEYA PRINCILA MARY", Mobile = "8778900700", Address = "WARD -1 D/NO-60N3, CHINNAMANUR MAIN ROAD, THEVARAM", City = "Theni", State = "Tamil Nadu", Pincode = "625530" },
                new StoreLocation { Id = 18, DealerName = "GASTON PLANTE POWER CORPORATION", ContactPerson = "SAMBATHRAJAN", Mobile = "9843871710", Address = "PLOT NO 1&2 KAVIMANI STREET, BYE PASS RAAD, NEHRU NAGAR", City = "Madurai", State = "Tamil Nadu", Pincode = "625016" },
                new StoreLocation { Id = 19, DealerName = "G- NEXTER ENERGIES", ContactPerson = "J MOHAMMED RIAZ JAFARULLAH", Mobile = "9994190901", Address = "G NEXT ENERGIES, THIRUVAMATHUR ROAD, VILLUPURAM BYE PASS ROAD", City = "Viluppuram", State = "Tamil Nadu", Pincode = "605602" },
                new StoreLocation { Id = 20, DealerName = "FINETECH SYSTEMS", ContactPerson = "P. NALLASIVAM", Mobile = "9842273559", Address = "3/177, DEVAMPALAYAM, PALANGARAI, AVANASHI", City = "Tirupur", State = "Tamil Nadu", Pincode = "641654" },
                new StoreLocation { Id = 21, DealerName = "DELTA SYSTEMS", ContactPerson = "JAGANATHAN PADMANABHAN", Mobile = "9443203324", Address = "256 KAMARAJ NAGAR COLONY", City = "Salem", State = "Tamil Nadu", Pincode = "636014" },
                new StoreLocation { Id = 22, DealerName = "Dev Electrical Ganjdundwara", ContactPerson = "Atul Gupta", Mobile = "9720411499", Address = "PWGR+QP7, Achalpur - Ganjdudwara Rd", City = "Kasganj", State = "Uttar Pradesh", Pincode = "207242" },
                new StoreLocation { Id = 23, DealerName = "Singhal Distributor", ContactPerson = "Mohit Agarwal", Mobile = "9837170344", Address = "A-578, Hapur Rd, Jawahar Gang, Lothi Gate Nagar, Ganga Nagar Colony", City = "Hapur", State = "Uttar Pradesh", Pincode = "245101" },
                new StoreLocation { Id = 24, DealerName = "Naveen electric", ContactPerson = "TEJPAL SINGH", Mobile = "9462505158", Address = "behror", City = "Alwar", State = "Rajasthan", Pincode = "301701" },
                new StoreLocation { Id = 25, DealerName = "Shree Shayam enterprises", ContactPerson = "Ajit singh", Mobile = "9799278745", Address = "manoharpur", City = "Churu", State = "Rajasthan", Pincode = "303103" },
                new StoreLocation { Id = 26, DealerName = "Maa Karni enterprises", ContactPerson = "SHAKTI SINGH KHINCHI", Mobile = "8764165732", Address = "BERI, ON GROUND, JHAJHAR ROAD", City = "Sikar", State = "Rajasthan", Pincode = "332031" },
                new StoreLocation { Id = 27, DealerName = "parveen Kumar and company", ContactPerson = "Davinder Garg", Mobile = "9530001174", Address = "68 A, NEW DHAN MANDI", City = "Hanumangarh", State = "Rajasthan", Pincode = "335513" },
                new StoreLocation { Id = 28, DealerName = "Suntech power system", ContactPerson = "GURTEJ KATARIA", Mobile = "9314408934", Address = "21 - NEW DHAN MANDI CHHOTI", City = "Shre Ganga Nagar", State = "Rajasthan", Pincode = "335001" },
                new StoreLocation { Id = 29, DealerName = "Sankhla electric store", ContactPerson = "Premraj Sankhla", Mobile = "9928044300", Address = "Sankhla Electric Store, Opp. Roadways Bustand", City = "Nagaur", State = "Rajasthan", Pincode = "341001" },
                new StoreLocation { Id = 30, DealerName = "Roxis infra power energy pvt.Ltd", ContactPerson = "Sanjay Kumawat", Mobile = "9214031462", Address = "P.NO.19, MITRA VIHAR-C, JATO KI DHANI, GAJSINGHPURA, VAISHALI NAGAR", City = "Jaipur", State = "Rajasthan", Pincode = "302021" },
                new StoreLocation { Id = 31, DealerName = "is solar", ContactPerson = "Naeem", Mobile = "9837793032", Address = "moradabad", City = "Moradabad", State = "Uttar Pradesh", Pincode = "244001" },
                new StoreLocation { Id = 32, DealerName = "Heliacal Urja", ContactPerson = "MANJU RAWAT", Mobile = "9837211548", Address = "KHADAKPUR DEVIPURA, VAISHALI COLONY, BAZPUR ROAD", City = "Kashipur", State = "Uttarakhand", Pincode = "244713" },
                new StoreLocation { Id = 33, DealerName = "Jasoria Marketvers", ContactPerson = "Jasoria Marketvers", Mobile = "7830000313", Address = "Ayub Khan Choraha", City = "Bareilly", State = "Uttar Pradesh", Pincode = "243001" },
                new StoreLocation { Id = 34, DealerName = "Pearl Enterprises", ContactPerson = "DEVANK JUNEJA", Mobile = "9758200022", Address = "38, ADARSH COLONY, CIVIL LINES RAMPUR", City = "Rampur", State = "Uttar Pradesh", Pincode = "244901" },
                new StoreLocation { Id = 35, DealerName = "M.R. Battery Services", ContactPerson = "rafik", Mobile = "9837537498", Address = "CHANDAUSI RAOD", City = "Sambhal", State = "Uttar Pradesh", Pincode = "244302" },
                new StoreLocation { Id = 36, DealerName = "Goel Enterprises", ContactPerson = "Deepak", Mobile = "7017726416", Address = "VILL MAKSOODPUR NAWADA NEAR GALAXY APARTMENT JOYA ROAD AMROHA", City = "Amroha", State = "Uttar Pradesh", Pincode = "244221" },
                new StoreLocation { Id = 37, DealerName = "Mama Trading Company", ContactPerson = "PARDEEP KUMAR", Mobile = "9927764041", Address = "Mota Aam, Shakoor Nagar, Najibabad", City = "Bijnor", State = "Uttar Pradesh", Pincode = "246763" },
                new StoreLocation { Id = 38, DealerName = "Bharat Power Corporation", ContactPerson = "MOHD HUZAIF", Mobile = "9259536731", Address = "KHATAULI COLD STORE, BUDHANA ROAD, NEAR SISHU SHIKSHA NIKETAN SCHOOL", City = "Muzaffarnagar", State = "Uttar Pradesh", Pincode = "251201" },
                new StoreLocation { Id = 39, DealerName = "Ritika Electronics", ContactPerson = "HARSH KUMAR DAWAR", Mobile = "9410223340", Address = "18 C, MANGAL NAGAR, NEAR POST OFFICE, NAWAB GANJ", City = "Saharanpur", State = "Uttar Pradesh", Pincode = "247001" },
                new StoreLocation { Id = 40, DealerName = "M/s Aligarh Power point", ContactPerson = "Bharat Kumar Gupta", Mobile = "9897198298", Address = "GROUND FLOOR, SHOP NO 2, MORDERN SHOPING CENTER, AGRA ROAD, NEAR GANDHI PARK", City = "Aligarh", State = "Uttar Pradesh", Pincode = "202001" },
                new StoreLocation { Id = 41, DealerName = "Innomindset LLP", ContactPerson = "Darpan", Mobile = "9897509407", Address = "A-76, SHRI RADHA PURAM, GANESHRA ROAD, NATIONAL HIGHWAY 19", City = "Mathura", State = "Uttar Pradesh", Pincode = "281001" },
                new StoreLocation { Id = 42, DealerName = "Singhal Solar Traders", ContactPerson = "Divyanshu Singhal", Mobile = "9528938181", Address = "Junction Road, Khurja", City = "Bulandshahr", State = "Uttar Pradesh", Pincode = "203131" },
                new StoreLocation { Id = 43, DealerName = "Upasana Saur Urja Kendra", ContactPerson = "Puneet Bansal", Mobile = "8899280702", Address = "NH-58, MEERUT DELHI BYPASS", City = "Meerut", State = "Uttar Pradesh", Pincode = "250001" },
                new StoreLocation { Id = 44, DealerName = "Green Field Energy", ContactPerson = "Manoj chauhan", Mobile = "7500656543", Address = "KHASRA NO. 197, MAUJA CHAKHAFFTAM JOHRA BAGH, RAM BAGH", City = "Agra", State = "Uttar Pradesh", Pincode = "282006" },
                new StoreLocation { Id = 45, DealerName = "M/s Bansal Energy System", ContactPerson = "Amit Bansal", Mobile = "9897545376", Address = "0, SHANTI KUNJ, 0, MURSAN GATE", City = "Hathras", State = "Uttar Pradesh", Pincode = "204101" },
                new StoreLocation { Id = 46, DealerName = "Radiant Solars", ContactPerson = "Ram Kumar", Mobile = "8273529872", Address = "718, GYANDEEP ROAD, KHERA MOHALLA", City = "Firozabad", State = "Uttar Pradesh", Pincode = "283135" },
                new StoreLocation { Id = 47, DealerName = "M/s Mahadev Traders", ContactPerson = "Usha Kumari", Mobile = "9870807461", Address = "593, NAI BASTI", City = "Etah", State = "Uttar Pradesh", Pincode = "207001" },
                new StoreLocation { Id = 48, DealerName = "KASHMIR VALLEY", ContactPerson = "ISHFAQ AHMED", Mobile = "9966287328", Address = "NATIONAL HIGHWAY ROAD, REVENUE MOUZA, DELINA BRANCH POST OFFICE, DILNA", City = "Baramulla", State = "Jammu & Kashmir", Pincode = "193201" },
                new StoreLocation { Id = 49, DealerName = "MAHADEV ENTERPRISES", ContactPerson = "Mr Moksh Yadav", Mobile = "8685832677", Address = "Near Gopal Dev Chownk Rewari, Opp Ceat Shopee", City = "Rewari", State = "Haryana", Pincode = "123401" },
                new StoreLocation { Id = 50, DealerName = "SWARN BATTERY", ContactPerson = "Mr Sharan Jit Singh", Mobile = "9810801817", Address = "Near Escorts Metro Station", City = "Faridabad", State = "Haryana", Pincode = "121006" },
                new StoreLocation { Id = 51, DealerName = "SHREE BALAJI TRADERS", ContactPerson = "Mr Anirudh", Mobile = "9050707078", Address = "Sondapur", City = "Panipat", State = "Haryana", Pincode = "132103" },
                new StoreLocation { Id = 52, DealerName = "MALIK TRADING COMPANY", ContactPerson = "Mr Bijender", Mobile = "8607356000", Address = "SHOP NO. 5, NEAR RAILWAY STATION, KAWI ROAD", City = "Panipat", State = "Haryana", Pincode = "132113" },
                new StoreLocation { Id = 53, DealerName = "ADVANCE MODULAR TECHNOLOGY", ContactPerson = "Mr Amit Malik", Mobile = "9466769467", Address = "123 NARENDRA NAGAR RATHDANA ROAD NEAR SBI BANK", City = "Sonipat", State = "Haryana", Pincode = "131001" },
                new StoreLocation { Id = 54, DealerName = "SAT SOLAR ENERGY PRIVATE LIMITED", ContactPerson = "Mr Madhukar", Mobile = "7206606112", Address = "SHOP NO. -32, MAIN MARKET, SECTOR 14", City = "Karnal", State = "Haryana", Pincode = "132001" },
                new StoreLocation { Id = 55, DealerName = "NISHAN AUTOMOBILES", ContactPerson = "Mr Virender CHUGH", Mobile = "9896691205", Address = "SHOP NO 4, OPP MARUTI SHOWROOM G.T ROAD", City = "Panipat", State = "Haryana", Pincode = "132103" },
                new StoreLocation { Id = 56, DealerName = "SHUBHAM BATTERY HOUSE", ContactPerson = "Mr Hritik", Mobile = "8683864142", Address = "C/O SUBE SINGH 46 WARD NO 09 SATPOLI MOHALLA", City = "Jhajjar", State = "Haryana", Pincode = "124103" },
                new StoreLocation { Id = 57, DealerName = "ISHAAN BRIGHT ENERGY", ContactPerson = "Mr Vimal", Mobile = "9671202019", Address = "40, Saini Colony, Jhansa Road", City = "Kurukshetra", State = "Haryana", Pincode = "136118" },
                new StoreLocation { Id = 58, DealerName = "Roorkee Solar Hub", ContactPerson = "Vikas Tyagi", Mobile = "8650115000", Address = "Delhi Rd, Asaf Nagar", City = "Roorkee", State = "Uttarakhand", Pincode = "247666" },
                new StoreLocation { Id = 59, DealerName = "Pune Energy Systems", ContactPerson = "Rahul Deshmukh", Mobile = "9823012345", Address = "Phase 2, Hinjewadi IT Park", City = "Pune", State = "Maharashtra", Pincode = "411057" }
            );
        }
    }
}