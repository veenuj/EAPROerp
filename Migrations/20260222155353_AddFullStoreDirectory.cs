using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EaproERP.Migrations
{
    /// <inheritdoc />
    public partial class AddFullStoreDirectory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreLocations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 21, 23, 53, 223, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 21, 23, 53, 223, DateTimeKind.Local).AddTicks(9180));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreLocations");

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 20, 31, 44, 112, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "ProjectEngines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommencementDate",
                value: new DateTime(2026, 2, 22, 20, 31, 44, 112, DateTimeKind.Local).AddTicks(8400));
        }
    }
}
