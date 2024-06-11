using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CourseWork.Data;
using CourseWork.Areas.Identity.Data;
using CourseWork.Services;

var builder = WebApplication.CreateBuilder(args);

var authConnectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection")
    ?? throw new InvalidOperationException("Connection string 'AuthDbContextConnection' not found.");
var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(authConnectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(defaultConnectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<UserService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/" && !context.User.Identity.IsAuthenticated)
    {
        context.Response.Redirect("/Identity/Account/Login");
        return;
    }
    await next();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "watchvideo",
        pattern: "WatchVideo/{action=Watch}/{id?}",
        defaults: new { controller = "WatchVideo" });
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
