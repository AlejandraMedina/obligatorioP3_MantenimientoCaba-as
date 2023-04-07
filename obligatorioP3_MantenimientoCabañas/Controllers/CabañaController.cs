using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using Aplicacion;

//using Negocio.ExcepcionesPropias;
//using Aplicacion;

   

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
        //public ActionResult Create()
        //{
         //   return View();
       // }



        


        // GET: TemasController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: CabañasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cabaña c)
        {
            try
            {
                // c.Validar();
                AltaCabaña.Alta(c);
                return RedirectToAction(nameof(Index));
            }
            //catch (NombreCabañaInvalidoException ex)
            //{
            //    ViewBag.Mensaje = ex.Message;
            //    return View();
            //}
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Oops! Ocurrió un error inesperado";
                return View();
            }
        }


        // POST: CabañasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cabaña t)
        {
            try
            {
               //c.Validar();
                //Repo.Update(t);
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
            try
            {
                //Repo.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Mensaje = "No se pudo eliminar la cabaña";
                return View();
            }
        }
    }
}
