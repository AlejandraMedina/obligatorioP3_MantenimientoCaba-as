using Datos.Repositorios;
using PresentacionMVC.Controllers;
using Dominio.InterfacesRespositorios;
using Aplicacion;
using Datos.EF;
using Microsoft.EntityFrameworkCore;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesNegocio;

namespace PresentacionMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //AGREGAR INFORMACIÓN PARA LA INYECCIÓN DE DEPENDENCIAS AUTOMÁTICA:
            builder.Services.AddScoped<IRepositorioCabañas, RepositorioCabañas>();
            builder.Services.AddScoped<IRepositorioTipos, RepositorioTipos>();
            builder.Services.AddScoped<IAltaCabaña, AltaCabaña>();
            builder.Services.AddScoped<IListadoCabañas, ListadoCabañas>();
            builder.Services.AddScoped<IListadoTipos, ListadoTipos>();
            
            builder.Services.AddScoped<IRepositorio<Cabaña>, RepositorioCabañas>();




            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json", false, true);
            var configuration = configurationBuilder.Build();

            string strCon = configuration.GetConnectionString("MiConexion");

            builder.Services.AddDbContext<MantenimientoCabañaContext>(options => options.UseSqlServer(strCon));

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
            pattern: "{controller=Cabaña}/{action=CreateCabaña}/{id?}");
    

            app.Run();
        }
    }
}