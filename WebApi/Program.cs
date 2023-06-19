using Aplicacion.Clases;
using Aplicacion.Interfacaces;
using Aplicacion.Interfaces;
using Datos.EF;
using Datos.Repositorios;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options => options.IncludeXmlComments("WebApi.xml"));

//builder.Services.AddSession();

////////////////// JWT ///////////////////////////////////
var claveSecreta = "ZZZWRpw6fDo28gZW0gY29tcHV0YWRvcmE="; //PUEDE SER OTRA CLAVE, SI ES FUERTE

builder.Services.AddAuthentication(aut =>
{
    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(aut =>
{
    aut.RequireHttpsMetadata = false;
    aut.SaveToken = true;
    aut.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(claveSecreta)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
//////////////////// FIN JWT ////////////////////////


//AGREGAR INFORMACIÓN PARA LA INYECCIÓN DE DEPENDENCIAS AUTOMÁTICA:
//repositorios
builder.Services.AddScoped<IRepositorioCabañas, RepositorioCabañas>();
builder.Services.AddScoped<IRepositorioMantenimientos, RepositorioMantenimientos>();
builder.Services.AddScoped<IRepositorioTipos, RepositorioTipos>();
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddScoped<IRepositorioParametros, RepositorioParametros>();

builder.Services.AddScoped<IRepositorio<Usuario>, RepositorioUsuarios>();
builder.Services.AddScoped<IRepositorio<Cabaña>, RepositorioCabañas>();
builder.Services.AddScoped<IRepositorio<Mantenimiento>, RepositorioMantenimientos>();
//casos de uso
builder.Services.AddScoped<IAltaCabaña, AltaCabaña>();
builder.Services.AddScoped<IAltaTipo, AltaTipo>();
builder.Services.AddScoped<IListadoCabañas, ListadoCabañas>();
builder.Services.AddScoped<IListadoTipos, ListadoTipos>();
builder.Services.AddScoped<IBuscarTipoPorId, BuscarTipoPorId>();
builder.Services.AddScoped<IModificarTipo, ModificarTipo>();
builder.Services.AddScoped<IEliminarTipo, EliminarTipo>();
builder.Services.AddScoped<IEliminarCabaña, EliminarCabaña>();

builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
builder.Services.AddScoped<IListadoUsuarios, ListadoUsuarios>();
builder.Services.AddScoped<IAltaMantenimiento, AltaMantenimiento>();
builder.Services.AddScoped<IListadoMantenimientos, ListadoMantenimientos>();
builder.Services.AddScoped<IBuscarPorNombre, BuscarPorNombre>();
builder.Services.AddScoped<IBuscarCabaña, BuscarCabaña>();



var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", false, true);
var configuration = configurationBuilder.Build();

string strCon = configuration.GetConnectionString("MiConexion");

builder.Services.AddDbContext<MantenimientoCabañaContext>(options => options.UseSqlServer(strCon));


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
