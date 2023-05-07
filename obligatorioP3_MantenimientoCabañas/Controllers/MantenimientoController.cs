using Aplicacion;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentacionMVC.Models;

namespace PresentacionMVC.Controllers
{
    public class MantenimientoController : Controller
    {

        public IListadoMantenimientos ListadoMantenimientos { get; set; }

        IAltaMantenimiento AltaMantenimiento { get; set; }

        public MantenimientoController(IAltaMantenimiento altaMantenimiento, IListadoCabañas listadoCabañas, ListadoMantenimientos listadoMantenimientos)
        {
            AltaMantenimiento = altaMantenimiento;
            ListadoMantenimientos = listadoMantenimientos;

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

        // GET: MantenimientoController/Create
        public ActionResult CreateMantenimiento()
        {
            AltaMantenimientoViewModel vm = new AltaMantenimientoViewModel();

            return View(vm);
        }

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMantenimiento(AltaMantenimientoViewModel vm)
        {
            try
            {
               
                AltaMantenimiento.Alta(vm.Mantenimiento);                

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
    }
}
