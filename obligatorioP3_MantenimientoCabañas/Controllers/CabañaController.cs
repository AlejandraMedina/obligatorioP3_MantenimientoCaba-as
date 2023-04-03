using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace obligatorioP3_MantenimientoCabañas.Controllers
{
    public class CabañaController : Controller
    {
        // GET: CabañasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CabañasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabañasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CabañasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CabañasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CabañasController/Edit/5
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
