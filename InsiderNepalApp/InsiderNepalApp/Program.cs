using InsiderNepalApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using InsiderNepalApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// whatever services are needed in application will be declared here.
builder.Services.AddDbContext<InsiderNepalDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

//builder.Services.AddDefaultIdentity<InsiderNepalAppUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<InsiderNepalDbContext>();
builder.Services.AddIdentity<InsiderNepalAppUser, IdentityRole>()
    .AddEntityFrameworkStores<InsiderNepalDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "admin",
        defaults: new { controller = "Home", action = "AdminPanel" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}");
});


//app.MapControllerRoute(


//    name: "default",
//    pattern: "{controller=Home}/{action=Index}");

using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
}
app.MapRazorPages();
app.Run();
