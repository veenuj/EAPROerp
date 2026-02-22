using EaproERP.Data;
using EaproERP.Hubs;
using EaproERP.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Standard MVC Services
builder.Services.AddControllersWithViews();

// 2. NEURAL SECURITY: Session Configuration
// Required for tracking Failed Login Attempts and Lockout Timers
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Extended for busy accounting sessions
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = ".EaproERP.Session";
});

// 3. Database Configuration (EAPRO SQL Node)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=EaproERP_DB;User Id=SA;Password=EaproERP_StrongPass123!;TrustServerCertificate=True;"));

// 4. IIoT & REAL-TIME SERVICES
builder.Services.AddSignalR();
builder.Services.AddHostedService<FactoryTelemetryService>();

var app = builder.Build();

// --- TITAN OS DATA INITIALIZATION HUB ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate(); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "CRITICAL: Neural Database Link Failure.");
    }
}

// 5. Middleware Pipeline (ORDER MATTERS)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// SESSION MUST BE PLACED HERE: After Routing, before Authorization/Endpoints
app.UseSession(); 

app.UseAuthorization();

// 6. Endpoint Mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<FactoryHub>("/factoryHub");

app.Run();