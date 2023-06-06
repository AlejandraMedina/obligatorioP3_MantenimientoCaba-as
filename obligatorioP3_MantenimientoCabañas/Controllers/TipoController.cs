using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio.EntidadesNegocio;
using ExcepcionesPropias;
using NuGet.Protocol;
using PresentacionMVC.Models;
using Dominio.InterfacesRepositorios;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Datos.Repositorios;
using Dominio.InterfacesRespositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Aplicacion.Interfaces;
using Aplicacion.Interfacaces;
using DTOs;

namespace PresentacionMVC.Controllers
{

    public class TipoController : Controller
    {

        IListadoTipos ListadoTipos { get; set; }
        IAltaTipo AltaTipo { get; set; }
        IModificarTipo ModificarTipo { get; set; }

        IEliminarTipo EliminarTipo { get; set; }

        IRepositorioTipos RepoTipo { get; set; }
        IRepositorioCabañas RepoCabaña { get; set; }

        IBuscarTipoPorId BuscarTipoPorId { get; set; }

      
        public TipoController(IListadoTipos listadoTipos, IAltaTipo altaTipo,IBuscarTipoPorId buscarTipoPorId, IModificarTipo modificarTipo, IEliminarTipo eliminarTipo, IRepositorioTipos repotipo, IRepositorioCabañas repocabaña)
        { 
        
            ListadoTipos = listadoTipos;
            AltaTipo = altaTipo;
            ModificarTipo = modificarTipo;
            EliminarTipo = eliminarTipo;
            RepoTipo = repotipo;
            RepoCabaña = repocabaña;  
            BuscarTipoPorId = buscarTipoPorId;          

        }


        // GET: TipoController
        public ActionResult Index()        {

            IEnumerable<TipoDTO> tipos = ListadoTipos.ObtenerListado();

            if (tipos.Count() == 0)
            {
                ViewBag.Mensaje = "No existen tipos para mostrar";
            }

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
               // AltaTipo.Alta(t);
                
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
               //No implementada no se pide
               
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
            Tipo t = RepoTipo.FindById(id);
            
            return View(t);
        }

        // POST: TipoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTipo(int id, IFormCollection collection)
        {
           
            try
            {
                RepoTipo.Remove(id);
                ViewBag.Mensaje = "El tipo fue eliminado con éxito";
                return RedirectToAction(nameof(Index));

            }         
             catch (Exception ex)
            {
                ViewBag.Mensaje = "No es posible eliminar el tipo ya que tiene cabañas asociadas";

                return View();
            }
          
            
            
        }


        // GET: TipoController/Edit/5
        public ActionResult BuscarTipoPorNombre()
        {

            return View();
        }


        // POST: TipoController/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarTipoPorNombre(string nombre)
        //{

        //    try
        //    {

        //       //Tipo tipo = RepoTipo.BuscarTipoPorNombre(nombre);

        //        return View(tipo);
        //    }
        //    catch
        //    {
        //        ViewBag.Mensaje = "No existe un tipo con el nombre ingresado";
        //        return View();
        //    }
           
        //}
       
    }
}
