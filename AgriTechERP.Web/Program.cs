using AgriTechERP.Core.Entidades.IdentityEntities;
using AgriTechERP.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
    .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; // requires at least one digit
    options.Password.RequireLowercase = true; // requires at least one lowercase letter
    options.Password.RequireUppercase = true; // requires at least one uppercase letter
    options.Password.RequireNonAlphanumeric = true; // requires at least one special character
    options.Password.RequiredLength = 6; // requires a minimum length
});

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

app.UseAuthentication(); // Leyendo Identity Cookies 

app.UseRouting(); // Identifying action method based route

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Cliente}/{controller=Home}/{action=Index}/{id?}");

app.Run();
