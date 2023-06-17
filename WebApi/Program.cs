using Aplicacion.Clases;
using Aplicacion.Interfacaces;
using Aplicacion.Interfaces;
using Datos.EF;
using Datos.Repositorios;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSession();

//AGREGAR INFORMACI�N PARA LA INYECCI�N DE DEPENDENCIAS AUTOM�TICA:
builder.Services.AddScoped<IRepositorioCaba�as, RepositorioCaba�as>();
builder.Services.AddScoped<IRepositorioMantenimientos, RepositorioMantenimientos>();
builder.Services.AddScoped<IRepositorioTipos, RepositorioTipos>();
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddScoped<IRepositorioParametros, RepositorioParametros>();
builder.Services.AddScoped<IAltaCaba�a, AltaCaba�a>();
builder.Services.AddScoped<IAltaTipo, AltaTipo>();
builder.Services.AddScoped<IListadoCaba�as, ListadoCaba�as>();
builder.Services.AddScoped<IListadoTipos, ListadoTipos>();
builder.Services.AddScoped<IBuscarTipoPorId, BuscarTipoPorId>();
builder.Services.AddScoped<IModificarTipo, ModificarTipo>();
builder.Services.AddScoped<IEliminarTipo, EliminarTipo>();
builder.Services.AddScoped<IEliminarCaba�a, EliminarCaba�a>();
builder.Services.AddScoped<IRepositorio<Usuario>, RepositorioUsuarios>();
builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
builder.Services.AddScoped<IListadoUsuarios, ListadoUsuarios>();
builder.Services.AddScoped<IAltaMantenimiento, AltaMantenimiento>();
builder.Services.AddScoped<IListadoMantenimientos, ListadoMantenimientos>();
builder.Services.AddScoped<IBuscarPorNombre, BuscarPorNombre>();


var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", false, true);
var configuration = configurationBuilder.Build();

string strCon = configuration.GetConnectionString("MiConexion");

builder.Services.AddDbContext<MantenimientoCaba�aContext>(options => options.UseSqlServer(strCon));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
