using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio.EntidadesNegocio;
using Aplicacion;
using Dominio.ExcepcionesPropias;
using NuGet.Protocol;
using PresentacionMVC.Models;

namespace PresentacionMVC.Controllers
{
    public class TipoController : Controller
    {

        IListadoTipos ListadoTipos { get; set; }
        IAltaTipo AltaTipo { get; set; }
        IModificarTipo ModificarTipo { get; set; }

        IEliminarTipo EliminarTipo { get; set; }

        public TipoController(IListadoTipos listadoTipos, IAltaTipo altaTipo, IModificarTipo modificarTipo, IEliminarTipo eliminarTipo)
        { 
        
            ListadoTipos = listadoTipos;
            AltaTipo = altaTipo;
            ModificarTipo = modificarTipo;
            EliminarTipo = eliminarTipo;
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
        public ActionResult EditTipo(int id)
        {                      
            return View();
        }

        // POST: TipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTipo(int id, Tipo t)
        {
            try
            {
                EliminarTipo.Remove(id);
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoController/Delete/5
        public ActionResult DeleteTipo(int id)
        {
          

            

            return View(id);
        }

        // POST: TipoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DTipo(int id)
        {
            try
            {
                EliminarTipo.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
