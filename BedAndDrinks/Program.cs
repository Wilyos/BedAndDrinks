using BedAndDrinks.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BedAndDrinkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

builder.Services.AddControllersWithViews(); // Agregar servicios MVC al contenedor de servicios
builder.Services.AddFluentValidationAutoValidation(); // Agregar validación automática de FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<UsuarioValidator>(); // Registra automáticamente todos los validadores en el ensamblado que contiene UsuarioValidator

// Habilitar autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Redireccionar si no está autenticado
        options.LogoutPath = "/Account/Logout"; // Ruta para cerrar sesión
        options.AccessDeniedPath = "/Account/AccessDenied"; // Acceso denegado
    });

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
