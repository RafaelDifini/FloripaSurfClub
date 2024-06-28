using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FloripaSurfClub.Data;
using FloripaSurfClub.Models;
using System.Text;
using FloripaSurfClubWeb.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Configurar banco de dados
builder.Services.AddDbContext<FloripaSurfClubContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Identity
builder.Services.AddIdentity<UsuarioSistema, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<FloripaSurfClubContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(6);
    options.LoginPath = "/Account/Login";
    options.SlidingExpiration = true;
});

builder.Services.AddControllersWithViews();
// Adicionar AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
