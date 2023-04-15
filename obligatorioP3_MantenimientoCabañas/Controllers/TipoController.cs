using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio.EntidadesNegocio;

using Aplicacion;
using Dominio.ExcepcionesPropias;

namespace PresentacionMVC.Controllers
{
    public class TipoController : Controller
    {

        IListadoTipos ListadoTipos { get; set; }
        IAltaTipo AltaTipo { get; set; }

        public TipoController(IListadoTipos listadoTipos, IAltaTipo altaTipo)
        {
            ListadoTipos = listadoTipos;
            AltaTipo = altaTipo;
        }

        // GET: TipoController
        public ActionResult Index()
        {
            IEnumerable<Tipo> tipos = ListadoTipos.ObtenerListado();
            return View(tipos);
        }

        // GET: TipoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoController/Create
        public ActionResult CreateTipo()
        {
            return View();
        }

        // POST: TipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTipo(Tipo t)
        {
            try
            {
                //t.Validar();
                AltaTipo.Alta(t);
                return RedirectToAction(nameof(Index));
            }
            catch (NombreTipoInvalidoException ex)
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

        // GET: TipoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoController/Edit/5
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

        // GET: TipoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoController/Delete/5
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
