using AccesoADatos;
using LogicaDeAplicacion.ImplementacionCU;
using LogicaDeAplicacion.InterfacesCU.Tareas;
using LogicaDeNegocios.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DbContext, Contexto>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection"))
    );

builder.Services.AddScoped(typeof(IRepositorioTarea), typeof(RepositorioTarea));

builder.Services.AddScoped(typeof(IAltaTarea), typeof(AltaTarea));
builder.Services.AddScoped(typeof(IGetTarea), typeof(GetTarea));
builder.Services.AddScoped(typeof(IEliminarTarea), typeof(EliminarTarea));
builder.Services.AddScoped(typeof(IModificarTarea), typeof(ModificarTarea));
builder.Services.AddScoped(typeof(IGetAllTareas), typeof(GetAllTareas));

// Add services to the container.
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
