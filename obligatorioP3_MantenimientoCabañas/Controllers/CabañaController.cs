using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using Aplicacion;
using Dominio.ExcepcionesPropias;
using Aplicacion;

   

namespace PresentacionMVC.Controllers
{
    public class CabañaController : Controller
    {

        IListadoCabañas ListadoCabañas { get; set; }

        IAltaCabaña AltaCabaña{ get; set; }


        public CabañaController(IListadoCabañas listadoCabañas, IAltaCabaña altaCabaña)
        {
            ListadoCabañas = listadoCabañas;
            AltaCabaña = altaCabaña;
        }


        // GET: CabañasController
        public ActionResult Index()
        {
            IEnumerable<Cabaña> cabañas = ListadoCabañas.ObtenerListado();
            return View(cabañas);
        }

        // GET: CabañasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabañasController/Create
        public ActionResult CreateCabaña()
        {
            return View();
        }





        // POST: CabañasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCabaña (Cabaña c)
        {
            try
            {
                c.Validar();
                AltaCabaña.Alta(c);
                return RedirectToAction(nameof(Index));
            }
            catch (NombreCabañaInvalidoException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Oops! Ocurrió un error inesperado";
                return View();
            }
        }


        // POST: CabañasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cabaña c)
        {
            try
            {
               c.Validar();
               //Repo.Update(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CabañasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CabañasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
           // Cabaña c = Repo.FindById(id);
           // return View(c);
            return View();
        }
    }
}
