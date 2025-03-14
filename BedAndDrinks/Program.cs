using BedAndDrinks.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BedAndDrinkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

builder.Services.AddControllersWithViews(); // Agregar servicios MVC al contenedor de servicios
builder.Services.AddFluentValidationAutoValidation(); // Agregar validación automática de FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<UsuarioValidator>(); // Registra automáticamente todos los validadores en el ensamblado que contiene UsuarioValidator

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
