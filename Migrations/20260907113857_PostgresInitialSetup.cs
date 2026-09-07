using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class PostgresInitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmcContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientName = table.Column<string>(type: "text", nullable: false),
                    ProjectSite = table.Column<string>(type: "text", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContractExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContractValue = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    ServiceFrequency = table.Column<string>(type: "text", nullable: false),
                    NextScheduledService = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmcContracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    ResumeUrl = table.Column<string>(type: "text", nullable: false),
                    CurrentStep = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestType = table.Column<string>(type: "text", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ProductSerialNumber = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessName = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    ContactPerson = table.Column<string>(type: "text", nullable: false),
                    Tier = table.Column<string>(type: "text", nullable: false),
                    AnnualTurnover = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    IsServiceCenter = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BiometricCredentialId = table.Column<byte[]>(type: "bytea", nullable: true),
                    BiometricPublicKey = table.Column<byte[]>(type: "bytea", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EmployeeCode = table.Column<string>(type: "text", nullable: false),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Bonus = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    AIPerformanceInsight = table.Column<string>(type: "text", nullable: true),
                    DateOfJoining = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EmergencyContact = table.Column<string>(type: "text", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "text", nullable: false),
                    IFSCCode = table.Column<string>(type: "text", nullable: false),
                    GovernmentId = table.Column<string>(type: "text", nullable: false),
                    JobLocation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    StockLevel = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    AIStockPrediction = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerGSTIN = table.Column<string>(type: "text", nullable: true),
                    BillingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsGstInvoice = table.Column<bool>(type: "boolean", nullable: false),
                    BaseAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxRate = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TransactionId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LineName = table.Column<string>(type: "text", nullable: false),
                    CurrentProduct = table.Column<string>(type: "text", nullable: false),
                    DailyTarget = table.Column<int>(type: "integer", nullable: false),
                    UnitsCompleted = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    QualityScore = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEngines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectName = table.Column<string>(type: "text", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: false),
                    SiteLocation = table.Column<string>(type: "text", nullable: false),
                    SystemCapacityKW = table.Column<double>(type: "double precision", nullable: false),
                    ProjectType = table.Column<string>(type: "text", nullable: false),
                    RoofType = table.Column<string>(type: "text", nullable: false),
                    ShadowAnalysisScore = table.Column<int>(type: "integer", nullable: false),
                    ExecutionProgress = table.Column<int>(type: "integer", nullable: false),
                    CurrentPhase = table.Column<string>(type: "text", nullable: false),
                    ContractValue = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    CommencementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEngines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolarProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientName = table.Column<string>(type: "text", nullable: false),
                    ProjectType = table.Column<string>(type: "text", nullable: false),
                    CapacityKW = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    ContractValue = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DealerName = table.Column<string>(type: "text", nullable: false),
                    ContactPerson = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Pincode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrustLedger",
                columns: table => new
                {
                    Index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false),
                    PreviousHash = table.Column<string>(type: "text", nullable: false),
                    Hash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrustLedger", x => x.Index);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    ContactPerson = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    OutstandingBalance = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    ReliabilityScore = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warranties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WarrantyPeriodMonths = table.Column<int>(type: "integer", nullable: false),
                    IsRegistered = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PunchInTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    PunchOutTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDisbursements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    MonthYear = table.Column<string>(type: "text", nullable: false),
                    TotalWorkingDays = table.Column<int>(type: "integer", nullable: false),
                    DaysPresent = table.Column<int>(type: "integer", nullable: false),
                    CalculatedGross = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    BonusAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    NetPayout = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DisbursedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDisbursements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryDisbursements_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AmcContracts",
                columns: new[] { "Id", "ClientName", "ContractExpiryDate", "ContractStartDate", "ContractValue", "NextScheduledService", "ProjectSite", "ServiceFrequency" },
                values: new object[] { 1, "Pacific Mall Dehradun", new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120000m, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Main Roof B", "Quarterly" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "AppliedDate", "CurrentStep", "Email", "Name", "Notes", "Position", "ResumeUrl", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "rahul.v@gmail.com", "Rahul Verma", null, "GenAI Developer", "", "Active" },
                    { 2, new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "sneha.k@eapro.in", "Sneha Kapoor", null, "Supply Chain Manager", "", "Active" },
                    { 3, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "aditya.v@outlook.com", "Vikram Aditya", null, "Embedded Systems Engineer", "", "Active" },
                    { 4, new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "pooja.h@gmail.com", "Pooja Hegde", null, "Technical Sales Executive", "", "Active" }
                });

            migrationBuilder.InsertData(
                table: "CustomerTickets",
                columns: new[] { "Id", "CreatedAt", "CustomerName", "Description", "Email", "PhoneNumber", "ProductSerialNumber", "RequestType", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), "Rakesh Tiwari", "Inverter is showing error code E-04 during power cut.", "rakesh.t@gmail.com", "+91-9876512345", "TRON-3200-S04-005", "Complaint", "Open" },
                    { 2, new DateTime(2026, 2, 18, 14, 15, 0, 0, DateTimeKind.Unspecified), "Meera Joshi", "Need installation for 5KW solar panels at my residence in Dehradun.", "meera.j@yahoo.com", "+91-8765423456", "EAPRO-590W-PANEL-SET", "Installation", "Resolved" },
                    { 3, new DateTime(2026, 2, 21, 9, 45, 0, 0, DateTimeKind.Unspecified), "Suresh Kumar", "Registering newly purchased battery for standard 5-year warranty.", "suresh.k@outlook.com", "+91-7654334567", "ENERBATT-250AH-001", "Product Registration", "Open" }
                });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "AnnualTurnover", "BusinessName", "ContactPerson", "IsServiceCenter", "Region", "Tier" },
                values: new object[,]
                {
                    { 1, 12500000m, "North Solar Hub Meerut", "Vikas Gupta", true, "North", "Platinum" },
                    { 2, 8500000m, "Roorkee Energy Solutions", "Anil Tyagi", true, "North", "Gold" },
                    { 3, 25000000m, "Delhi Solar Power Systems", "Sandeep Malhotra", false, "North", "Platinum" },
                    { 4, 4500000m, "Southern Energy Chennai", "K. Ramakrishnan", true, "South", "Silver" },
                    { 5, 9800000m, "Western Solar Pune", "Rahul Deshmukh", false, "West", "Gold" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AIPerformanceInsight", "BankAccountNumber", "BaseSalary", "BiometricCredentialId", "BiometricPublicKey", "Bonus", "DateOfJoining", "Department", "Designation", "Email", "EmergencyContact", "EmployeeCode", "GovernmentId", "IFSCCode", "JobLocation", "Name", "Phone" },
                values: new object[,]
                {
                    { 101, null, "", 45000m, null, null, 5000m, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manufacturing", "Plant Supervisor", "amit.sharma@eapro.in", "", "EAP-2301-1001", "ABCDE1234F", "", "Roorkee", "Amit Sharma", "+91-9876543210" },
                    { 102, null, "", 85000m, null, null, 18000m, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "R&D", "DSP Solar Engineer", "priya.singh@eapro.in", "", "EAP-2305-1002", "456789012345", "", "Roorkee", "Priya Singh", "+91-8765432109" }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "AIStockPrediction", "Category", "Name", "Price", "StockLevel" },
                values: new object[,]
                {
                    { 1, "", "Inverter", "EAPRO TRON-3200 3000VA 24V AI-MPPT Dual Battery PCU", 19349m, 45 },
                    { 2, "", "Inverter", "EAPRO 3500VA 48V MPPT Single Phase Pure Sine Wave", 31570m, 18 },
                    { 5, "", "Solar Panel", "EAPRO 590W TOPCon Bifacial Solar Panel", 18500m, 120 },
                    { 9, "", "Battery", "EAPRO Enerbatt 250Ah Solar Battery", 16500m, 60 }
                });

            migrationBuilder.InsertData(
                table: "ProductionLines",
                columns: new[] { "Id", "CurrentProduct", "DailyTarget", "LineName", "QualityScore", "Status", "UnitsCompleted" },
                values: new object[,]
                {
                    { 1, "TRON-3200 AI-MPPT", 250, "Line Alpha-1", 99.5m, "Active", 180 },
                    { 2, "590W TOPCon Bifacial", 500, "Line Beta-Sigma", 98.8m, "Active", 410 }
                });

            migrationBuilder.InsertData(
                table: "ProjectEngines",
                columns: new[] { "Id", "ClientName", "CommencementDate", "ContractValue", "CurrentPhase", "ExecutionProgress", "ProjectName", "ProjectType", "RoofType", "ShadowAnalysisScore", "SiteLocation", "SystemCapacityKW" },
                values: new object[,]
                {
                    { 1, "UP Health Dept", new DateTime(2026, 9, 7, 17, 8, 56, 910, DateTimeKind.Local).AddTicks(3100), 12500000m, "Installation", 65, "Roorkee Medical College Solar Hub", "On-Grid", "RRC Slab", 0, "Roorkee, UK", 450.0 },
                    { 2, "Smart City Auth", new DateTime(2026, 9, 7, 17, 8, 56, 910, DateTimeKind.Local).AddTicks(4280), 4200000m, "Site Survey", 15, "Meerut IT Park Unit 4", "Hybrid", "RRC Slab", 0, "Meerut, UP", 120.5 }
                });

            migrationBuilder.InsertData(
                table: "StoreLocations",
                columns: new[] { "Id", "Address", "City", "ContactPerson", "DealerName", "Mobile", "Pincode", "State" },
                values: new object[,]
                {
                    { 1, "Sarojini Nagar, Amausi", "Lucknow", "Srikant Dubey", "GENSTAR AGROVET FARMS", "9935200038", "226008", "Uttar Pradesh" },
                    { 2, "No 8 Tholkappiyar street Arcot, Anna silai", "Vellore", "Thanigai Malai", "Power tech Electronics", "9789586737", "632503", "Tamil Nadu" },
                    { 3, "7, BRINDHA GARDEN, SASTRY NAGAR, VAIKKAMEDU", "Erode", "KARTHIGAIVENI", "Inspire Energy care", "9940652303", "638002", "Tamil Nadu" },
                    { 4, "4/5, POOTTAI MAIN ROAD", "Kallakkurichi", "PERUMAL SATHEESH KUMAR", "STAR ELECTRICAL", "9698903550", "606401", "Tamil Nadu" },
                    { 5, "NO 15, WARRIOR HOUSE, BHARATHIDASAN STREET, TEACHERS COLONY", "Erode", "MR.P.SRINIVASAN", "WARRIOR POWER SYSTEM S", "7200281000", "638011", "Tamil Nadu" },
                    { 6, "121 othavada Street kodapakkm, Avm", "Chennai", "Thomas", "VINT ENTERPRISES", "8807191615", "600024", "Tamil Nadu" },
                    { 7, "Konnur high road, 5th St, railway quarters, Ayanavaram", "Chennai", "Mr. ganesh kumar", "Thirumal Enterprises", "9840191279", "600023", "Tamil Nadu" },
                    { 8, "BUILDING NO. 17, 1ST MAIN STREET, MVM NAGAR", "Dindigul", "MR. PARTHASARATHI PERUMAL KANNIAPPAN", "TED VAAA GLOBAL ENTERPRISE", "9442233383", "624004", "Tamil Nadu" },
                    { 9, "Joseph convent complex, opp Joseph convent", "Kanyakumari", "GEORGEMARIAARPUTHAM GEORGEFERNANDO", "SUN TRADERS", "8122434145", "629001", "Tamil Nadu" },
                    { 10, "S.F. NO. 308/1B1A, NITHYA, TIRUCHENGODE ROAD, PALLIPALAYAM", "Namakkal", "NITHYA GURUMOORTHY", "SSM BATTERIES", "9865884748", "638006", "Tamil Nadu" },
                    { 11, "no 14 konar street jaihindpuram", "Madurai", "MR. SELVAPRAKASH MURUGESAN", "PRAKASH GREEN ENERGY", "9994901500", "625011", "Tamil Nadu" },
                    { 12, "no-1 9 th Lane 1 St cross street Adayar, sastri nagar", "Chennai", "Jagathes", "POWER HOUSE", "9962869007", "620020", "Tamil Nadu" },
                    { 13, "NO 1/105, 52ND STREET, 7TH AVENUE, ASHOK NAGAR", "Chennai", "SUBHASHREE", "OMEGA DIGITAL SYSTEMS", "9667891576", "600083", "Tamil Nadu" },
                    { 14, "3/188-A, MAIN ROAD, POOLANGULAM, ALANGULAM", "Tirunelveli", "R MUTHUSELVI", "MSM TAMIL TRADERS", "6369922811", "627415", "Tamil Nadu" },
                    { 15, "395/1A1, CHENNAI BYE PASS HIGH WAY CIRCLE, NEAR SBI ATM", "Krishnagiri", "KARIYAPPA SIDDANNAN VEERABADRAN", "MICRO BATTERY HOUSE", "9943905073", "635001", "Tamil Nadu" },
                    { 16, "PLOT NO 23, VEERAIYA STREET, KUNDUPALAYAM, THATTANCHAVADY", "Pondicherry", "SELVA KUMAR", "LIGHTNING POWER CONTROL", "9843438701", "605009", "Puducherry" },
                    { 17, "WARD -1 D/NO-60N3, CHINNAMANUR MAIN ROAD, THEVARAM", "Theni", "JEYA PRINCILA MARY", "JEYAS SOLAR AND POWER SERVICE", "8778900700", "625530", "Tamil Nadu" },
                    { 18, "PLOT NO 1&2 KAVIMANI STREET, BYE PASS RAAD, NEHRU NAGAR", "Madurai", "SAMBATHRAJAN", "GASTON PLANTE POWER CORPORATION", "9843871710", "625016", "Tamil Nadu" },
                    { 19, "G NEXT ENERGIES, THIRUVAMATHUR ROAD, VILLUPURAM BYE PASS ROAD", "Viluppuram", "J MOHAMMED RIAZ JAFARULLAH", "G- NEXTER ENERGIES", "9994190901", "605602", "Tamil Nadu" },
                    { 20, "3/177, DEVAMPALAYAM, PALANGARAI, AVANASHI", "Tirupur", "P. NALLASIVAM", "FINETECH SYSTEMS", "9842273559", "641654", "Tamil Nadu" },
                    { 21, "256 KAMARAJ NAGAR COLONY", "Salem", "JAGANATHAN PADMANABHAN", "DELTA SYSTEMS", "9443203324", "636014", "Tamil Nadu" },
                    { 22, "PWGR+QP7, Achalpur - Ganjdudwara Rd", "Kasganj", "Atul Gupta", "Dev Electrical Ganjdundwara", "9720411499", "207242", "Uttar Pradesh" },
                    { 23, "A-578, Hapur Rd, Jawahar Gang, Lothi Gate Nagar, Ganga Nagar Colony", "Hapur", "Mohit Agarwal", "Singhal Distributor", "9837170344", "245101", "Uttar Pradesh" },
                    { 24, "behror", "Alwar", "TEJPAL SINGH", "Naveen electric", "9462505158", "301701", "Rajasthan" },
                    { 25, "manoharpur", "Churu", "Ajit singh", "Shree Shayam enterprises", "9799278745", "303103", "Rajasthan" },
                    { 26, "BERI, ON GROUND, JHAJHAR ROAD", "Sikar", "SHAKTI SINGH KHINCHI", "Maa Karni enterprises", "8764165732", "332031", "Rajasthan" },
                    { 27, "68 A, NEW DHAN MANDI", "Hanumangarh", "Davinder Garg", "parveen Kumar and company", "9530001174", "335513", "Rajasthan" },
                    { 28, "21 - NEW DHAN MANDI CHHOTI", "Shre Ganga Nagar", "GURTEJ KATARIA", "Suntech power system", "9314408934", "335001", "Rajasthan" },
                    { 29, "Sankhla Electric Store, Opp. Roadways Bustand", "Nagaur", "Premraj Sankhla", "Sankhla electric store", "9928044300", "341001", "Rajasthan" },
                    { 30, "P.NO.19, MITRA VIHAR-C, JATO KI DHANI, GAJSINGHPURA, VAISHALI NAGAR", "Jaipur", "Sanjay Kumawat", "Roxis infra power energy pvt.Ltd", "9214031462", "302021", "Rajasthan" },
                    { 31, "moradabad", "Moradabad", "Naeem", "is solar", "9837793032", "244001", "Uttar Pradesh" },
                    { 32, "KHADAKPUR DEVIPURA, VAISHALI COLONY, BAZPUR ROAD", "Kashipur", "MANJU RAWAT", "Heliacal Urja", "9837211548", "244713", "Uttarakhand" },
                    { 33, "Ayub Khan Choraha", "Bareilly", "Jasoria Marketvers", "Jasoria Marketvers", "7830000313", "243001", "Uttar Pradesh" },
                    { 34, "38, ADARSH COLONY, CIVIL LINES RAMPUR", "Rampur", "DEVANK JUNEJA", "Pearl Enterprises", "9758200022", "244901", "Uttar Pradesh" },
                    { 35, "CHANDAUSI RAOD", "Sambhal", "rafik", "M.R. Battery Services", "9837537498", "244302", "Uttar Pradesh" },
                    { 36, "VILL MAKSOODPUR NAWADA NEAR GALAXY APARTMENT JOYA ROAD AMROHA", "Amroha", "Deepak", "Goel Enterprises", "7017726416", "244221", "Uttar Pradesh" },
                    { 37, "Mota Aam, Shakoor Nagar, Najibabad", "Bijnor", "PARDEEP KUMAR", "Mama Trading Company", "9927764041", "246763", "Uttar Pradesh" },
                    { 38, "KHATAULI COLD STORE, BUDHANA ROAD, NEAR SISHU SHIKSHA NIKETAN SCHOOL", "Muzaffarnagar", "MOHD HUZAIF", "Bharat Power Corporation", "9259536731", "251201", "Uttar Pradesh" },
                    { 39, "18 C, MANGAL NAGAR, NEAR POST OFFICE, NAWAB GANJ", "Saharanpur", "HARSH KUMAR DAWAR", "Ritika Electronics", "9410223340", "247001", "Uttar Pradesh" },
                    { 40, "GROUND FLOOR, SHOP NO 2, MORDERN SHOPING CENTER, AGRA ROAD, NEAR GANDHI PARK", "Aligarh", "Bharat Kumar Gupta", "M/s Aligarh Power point", "9897198298", "202001", "Uttar Pradesh" },
                    { 41, "A-76, SHRI RADHA PURAM, GANESHRA ROAD, NATIONAL HIGHWAY 19", "Mathura", "Darpan", "Innomindset LLP", "9897509407", "281001", "Uttar Pradesh" },
                    { 42, "Junction Road, Khurja", "Bulandshahr", "Divyanshu Singhal", "Singhal Solar Traders", "9528938181", "203131", "Uttar Pradesh" },
                    { 43, "NH-58, MEERUT DELHI BYPASS", "Meerut", "Puneet Bansal", "Upasana Saur Urja Kendra", "8899280702", "250001", "Uttar Pradesh" },
                    { 44, "KHASRA NO. 197, MAUJA CHAKHAFFTAM JOHRA BAGH, RAM BAGH", "Agra", "Manoj chauhan", "Green Field Energy", "7500656543", "282006", "Uttar Pradesh" },
                    { 45, "0, SHANTI KUNJ, 0, MURSAN GATE", "Hathras", "Amit Bansal", "M/s Bansal Energy System", "9897545376", "204101", "Uttar Pradesh" },
                    { 46, "718, GYANDEEP ROAD, KHERA MOHALLA", "Firozabad", "Ram Kumar", "Radiant Solars", "8273529872", "283135", "Uttar Pradesh" },
                    { 47, "593, NAI BASTI", "Etah", "Usha Kumari", "M/s Mahadev Traders", "9870807461", "207001", "Uttar Pradesh" },
                    { 48, "NATIONAL HIGHWAY ROAD, REVENUE MOUZA, DELINA BRANCH POST OFFICE, DILNA", "Baramulla", "ISHFAQ AHMED", "KASHMIR VALLEY", "9966287328", "193201", "Jammu & Kashmir" },
                    { 49, "Near Gopal Dev Chownk Rewari, Opp Ceat Shopee", "Rewari", "Mr Moksh Yadav", "MAHADEV ENTERPRISES", "8685832677", "123401", "Haryana" },
                    { 50, "Near Escorts Metro Station", "Faridabad", "Mr Sharan Jit Singh", "SWARN BATTERY", "9810801817", "121006", "Haryana" },
                    { 51, "Sondapur", "Panipat", "Mr Anirudh", "SHREE BALAJI TRADERS", "9050707078", "132103", "Haryana" },
                    { 52, "SHOP NO. 5, NEAR RAILWAY STATION, KAWI ROAD", "Panipat", "Mr Bijender", "MALIK TRADING COMPANY", "8607356000", "132113", "Haryana" },
                    { 53, "123 NARENDRA NAGAR RATHDANA ROAD NEAR SBI BANK", "Sonipat", "Mr Amit Malik", "ADVANCE MODULAR TECHNOLOGY", "9466769467", "131001", "Haryana" },
                    { 54, "SHOP NO. -32, MAIN MARKET, SECTOR 14", "Karnal", "Mr Madhukar", "SAT SOLAR ENERGY PRIVATE LIMITED", "7206606112", "132001", "Haryana" },
                    { 55, "SHOP NO 4, OPP MARUTI SHOWROOM G.T ROAD", "Panipat", "Mr Virender CHUGH", "NISHAN AUTOMOBILES", "9896691205", "132103", "Haryana" },
                    { 56, "C/O SUBE SINGH 46 WARD NO 09 SATPOLI MOHALLA", "Jhajjar", "Mr Hritik", "SHUBHAM BATTERY HOUSE", "8683864142", "124103", "Haryana" },
                    { 57, "40, Saini Colony, Jhansa Road", "Kurukshetra", "Mr Vimal", "ISHAAN BRIGHT ENERGY", "9671202019", "136118", "Haryana" },
                    { 58, "Delhi Rd, Asaf Nagar", "Roorkee", "Vikas Tyagi", "Roorkee Solar Hub", "8650115000", "247666", "Uttarakhand" },
                    { 59, "Phase 2, Hinjewadi IT Park", "Pune", "Rahul Deshmukh", "Pune Energy Systems", "9823012345", "411057", "Maharashtra" }
                });

            migrationBuilder.InsertData(
                table: "TrustLedger",
                columns: new[] { "Index", "Data", "Hash", "PreviousHash", "ProductId", "Timestamp" },
                values: new object[,]
                {
                    { 1, "GENESIS: Manufacturing Started (Roorkee Unit 4)", "816E2247E11695CBA365930039E1C2E1", "0", "TRON-3200-S04-001", new DateTime(2026, 2, 20, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "QC Passed: Pure Sine Wave Efficiency 98.5%", "2C8C3886A26B5061B465228D7017A44F", "816E2247E11695CBA365930039E1C2E1", "TRON-3200-S04-001", new DateTime(2026, 2, 20, 14, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Category", "CompanyName", "ContactPerson", "Email", "OutstandingBalance", "ReliabilityScore", "Status" },
                values: new object[,]
                {
                    { 1, "Electronics", "Silicon Tech Japan", "Kenji Sato", "sato@silicontech.jp", 4500000m, 98, "Active" },
                    { 2, "Logistics", "Delta Logistics Meerut", "Vikas Tyagi", "v.tyagi@deltalog.in", 125000m, 85, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Warranties",
                columns: new[] { "Id", "CustomerName", "IsRegistered", "ProductName", "PurchaseDate", "SerialNumber", "WarrantyPeriodMonths" },
                values: new object[] { 1, "Anuj Dhiman", true, "Tron 3200 PCU", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "TRON-3200-S04-001", 24 });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_EmployeeId",
                table: "AttendanceRecords",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDisbursements_EmployeeId",
                table: "SalaryDisbursements",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmcContracts");

            migrationBuilder.DropTable(
                name: "AttendanceRecords");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "CustomerTickets");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ProductionLines");

            migrationBuilder.DropTable(
                name: "ProjectEngines");

            migrationBuilder.DropTable(
                name: "SalaryDisbursements");

            migrationBuilder.DropTable(
                name: "SolarProjects");

            migrationBuilder.DropTable(
                name: "StoreLocations");

            migrationBuilder.DropTable(
                name: "TrustLedger");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Warranties");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
