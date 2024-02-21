using FacturacionSimple;
using FacturacionSimple.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FacturacionSimple.Servicios;
using FacturacionSimple.Contexto;

var builder = WebApplication.CreateBuilder(args);
Memoria.Facturas = new();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<IFSDbContext, FSDbContext>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IFacturaServices,FacturaServices>();
var app = builder.Build();
//
#region Inicializar la base de datos
using var scoped = app.Services.CreateScope();
var service = scoped.ServiceProvider.GetRequiredService<FSDbContext>();
service.Database.EnsureCreated();
#endregion
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
