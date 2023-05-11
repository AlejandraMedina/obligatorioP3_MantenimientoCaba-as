using Aplicacion;
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

        public MantenimientoController(IAltaMantenimiento altaMantenimiento, IListadoCabañas listadoCabañas,  IRepositorioCabañas repoCabañas, IListadoMantenimientos listadoMantenimientos, IRepositorioMantenimientos repoMantenimientos)
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
        public ActionResult Details(int id)
        {
            return View();
        }

        //// GET: MantenimientoController/Create
        public ActionResult CreateMantenimiento(int id)
        {
            AltaMantenimientoViewModel vm = new AltaMantenimientoViewModel();
            vm.IdCabañaSeleccionada = id;

            return View(vm);
        }

        //// POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMantenimiento(AltaMantenimientoViewModel vm)
        {
            try
            {
                vm.Cabaña = RepoCabañas.FindById(vm.IdCabañaSeleccionada);
                vm.Mantenimiento.Cabania = RepoCabañas.FindById(vm.IdCabañaSeleccionada);               
                vm.Mantenimiento.IdCabania = vm.IdCabañaSeleccionada;
                int id = vm.IdCabañaSeleccionada;

                IEnumerable<Mantenimiento> mantenimientos = RepoMantenimientos.FindAll();

                int contador = 0;

                foreach (var item in mantenimientos) {
                    if (item.Cabania.Id == vm.Cabaña.Id) {
                        contador++;
                    }
                }

                if(contador < 3)
                {                   
                    AltaMantenimiento.Alta(vm.Mantenimiento);
                    return RedirectToAction(nameof(ListarMantenimientosDeCabaña), new { id = id });
                }

                ViewBag.Mensaje = "Esta cabaña ya tiene 3 mantenimientos realizados.";


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Oops! Ocurrió un error inesperado";

                return View(vm);
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
        public  IActionResult ListarMantenimientosDeCabaña(int id)
        {

            List<Mantenimiento> aux = new List<Mantenimiento>();

            foreach (Mantenimiento m in ListadoMantenimientos.ObtenerListado())
            {

                if (m.IdCabania == id)
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
