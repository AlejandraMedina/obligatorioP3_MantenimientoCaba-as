using Aplicacion;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
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

        public MantenimientoController(IAltaMantenimiento altaMantenimiento, IListadoCabañas listadoCabañas,  IRepositorioCabañas repoCabañas, IListadoMantenimientos listadoMantenimientos, IRepositorioMantenimientos RepoMantenimientos)
        {
            AltaMantenimiento = altaMantenimiento;        
            RepoCabañas = repoCabañas;
            ListadoMantenimientos = listadoMantenimientos;
            RepoMantenimientos = RepoMantenimientos;
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
                AltaMantenimiento.Alta(vm.Mantenimiento);


                return RedirectToAction(nameof(ListarMantenimientosDeCabaña),new {id = id });
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
    }
}
