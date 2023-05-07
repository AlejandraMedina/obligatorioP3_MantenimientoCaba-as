﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio.EntidadesNegocio;
using Aplicacion;
using Dominio.ExcepcionesPropias;
using NuGet.Protocol;
using PresentacionMVC.Models;
using Dominio.InterfacesRepositorios;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Datos.Repositorios;
using Dominio.InterfacesRespositorios;

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

        public TipoController(IListadoTipos listadoTipos, IAltaTipo altaTipo, IModificarTipo modificarTipo, IEliminarTipo eliminarTipo, IRepositorioTipos repotipo, IRepositorioCabañas repocabaña)
        { 
        
            ListadoTipos = listadoTipos;
            AltaTipo = altaTipo;
            ModificarTipo = modificarTipo;
            EliminarTipo = eliminarTipo;
            RepoTipo = repotipo;
            RepoCabaña = repocabaña;
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
        public ActionResult DeleteTipo( Tipo t)
        {
           
            try
            {
                bool aux = false;

                /*foreach (var item in RepoCabaña.FindAll())
                {
                if (item.Tipo.Id == id)
                    //    //{
                    //    //    aux = true;
                    //    //}
                    //    //if (!aux)
                    //    //{

                    //    //}
                    //}*/
                    EliminarTipo.Remove(t.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Mensaje = "Oops! Ocurrió un error inesperado";
                return View();
            }
            
        }
    }
}
