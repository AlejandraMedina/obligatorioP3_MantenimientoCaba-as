using Aplicacion.Interfaces;
//using Datos.Migrations;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentacionMVC.Models;

namespace PresentacionMVC.Controllers
{

    public class MantenimientoController : Controller
    {

        public IListadoMantenimientos ListadoMantenimientos { get; set; }
        public IRepositorioCabañas RepoCabañas { get; set; }

        public IRepositorioMantenimientos RepoMantenimientos { get; set; }

        IAltaMantenimiento AltaMantenimiento { get; set; }

        public MantenimientoController(IAltaMantenimiento altaMantenimiento, IListadoCabañas listadoCabañas, IRepositorioCabañas repoCabañas, IListadoMantenimientos listadoMantenimientos, IRepositorioMantenimientos repoMantenimientos)
        {
            AltaMantenimiento = altaMantenimiento;
            RepoCabañas = repoCabañas;
            ListadoMantenimientos = listadoMantenimientos;
            RepoMantenimientos = repoMantenimientos;
        }

        // GET: MantenimientoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MantenimientoController/Details/5
        public ActionResult Details(int IdCabañaSeleccionada)
        {
            return View();
        }

        //[Context.Session.GetString("usuarioLogueado") == "si" && Context.Session.GetString("Menu") == "si")]
        //// GET: MantenimientoController/Create
        public ActionResult CreateMantenimiento(int id)
        {
            AltaMantenimientoViewModel vm = new AltaMantenimientoViewModel();
            vm.Id = id;

            return View(vm);
        }

        //// POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMantenimiento(AltaMantenimientoViewModel vm)
        {
            try
            {

                Cabaña cabaña = RepoCabañas.FindById(vm.Id);
                vm.Mantenimiento.Cabania = cabaña;

                if (vm.Mantenimiento.Fecha.Date <= DateTime.Now.Date)
                {
                    ViewBag.Mensaje = "la fecha no puede ser anterior a la fecha de hoy";
                }

                int contador = 0;

                contador = RepoMantenimientos.MantenimientosPorCabaña(vm.Id).Count();

                
                if (contador < 3)
                {          
                    Mantenimiento m = new Mantenimiento();

                    m.Fecha = vm.Mantenimiento.Fecha;
                    m.Funcionario = vm.Mantenimiento.Funcionario;
                    m.Cabania = cabaña;
                    m.Descripcion = vm.Mantenimiento.Descripcion;
                    m.Costo = vm.Mantenimiento.Costo;

                    AltaMantenimiento.Alta(m);

                    ViewBag.Mensaje = "Se agregó el mantenimiento con éxito!";
                    return View(vm);
                }

                ViewBag.Mensaje = "Esta cabaña ya tiene 3 mantenimientos realizados.";

                  return View(vm); ;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;

                return View();
            }
        }

        // GET: MantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: MantenimientoController
        public  ActionResult ListarMantenimientosDeCabaña(int Id)
        {

            List<Mantenimiento> aux =  new List<Mantenimiento>();

            foreach (Mantenimiento m in ListadoMantenimientos.ObtenerListado())
            {

                if (m.CabaniaId == Id)
                {
                    aux.Add(m);
                }
            }
            return View(aux);
           
        }


        // GET: MantenimientoController/
        public ActionResult MantenimientosPorCabañaPorFechas(int id)
        {
            
         
            return View(new List<Mantenimiento>());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: MantenimientoController/
        public ActionResult MantenimientosPorCabañaPorFechas(DateTime inicio, DateTime fin, int id)
        {
       
            IEnumerable<Mantenimiento> mantenimientos = RepoMantenimientos.MantenimientosPorCabañaPorFechas(inicio,fin,id);
   

            if (mantenimientos.Count() == 0)
            {
                ViewBag.Mensaje = "No hay mantenimientos para la búsqueda realizada";
            }
            return View(mantenimientos);

        }
    }
}
