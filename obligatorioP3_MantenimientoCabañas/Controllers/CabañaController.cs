using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using ExcepcionesPropias;
using PresentacionMVC.Models;
using System.Globalization;
using Datos.Repositorios;
using System.Collections.Generic;
using Dominio.InterfacesRepositorios;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Authorization;
using Aplicacion.Interfaces;

namespace PresentacionMVC.Controllers
{

    public class CabañaController : Controller
    {

        public IListadoTipos ListadoTipos { get; set; }
        public IListadoCabañas ListadoCabañas { get; set; }

        public IRepositorioCabañas RepoCabañas { get; set; }

        public IRepositorioTipos RepoTipo { get; set; }

      

        IAltaCabaña AltaCabaña{ get; set; }

        IEliminarCabaña EliminarCabaña { get; set; }
        IListadoCabañas listadoCabañas { get; set; }

        public IWebHostEnvironment WHE { get; set; }

        public CabañaController(IListadoTipos listadoTipos, IRepositorioCabañas repo, IWebHostEnvironment whe, IRepositorioTipos repoTipo, IAltaCabaña altaCabaña, IListadoCabañas listadoCabañas)
        {
            ListadoTipos = listadoTipos;
            RepoCabañas = repo;
            RepoTipo = repoTipo;
            WHE = whe;
            AltaCabaña = altaCabaña;           
            ListadoCabañas = listadoCabañas;           
         }



        // GET: CabañasController
        public ActionResult Index()
        {
            IEnumerable<Cabaña> cabañas = ListadoCabañas.ObtenerListado();

            IEnumerable<Tipo> tipos = ListadoTipos.ObtenerListado();
            ViewBag.Tipos = tipos;

            if (cabañas.Count()==0)
            {
                ViewBag.Mensaje = "No hay cabañas disponibles para mostrar";
            }
            return View(cabañas);
        }

        

        // GET: CabañasController/Create
        public ActionResult CreateCabaña()
        {
           //Para que se carguen los tipos de cabaña en el desplegable de la vista inicial
            AltaCabañaViewModel vm = new AltaCabañaViewModel();
            IEnumerable<Tipo> tipos = ListadoTipos.ObtenerListado();
            vm.Tipos = tipos;         

            return View(vm);
        }



        // POST: CabañasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCabaña (AltaCabañaViewModel vm)
        {
            try
            {
                string rutaWwwRoot = WHE.WebRootPath;
                string rutaCarpeta = Path.Combine(rutaWwwRoot, "Imagenes");

                //Se obtiene la extensión del archivo que subieron

                FileInfo fi = new FileInfo(vm.Foto.FileName);
                string extension = fi.Extension;

                //se puede validar aca que sea png o jpg y devolver excepcion si no es valido el archivo
                //mejor si lo podemos validar en la vista así no manda el post

                string nomArchivo = vm.Cabaña.Nombre + "_001." + extension;

               

                //Genero la ruta de la carpeta que guardaré en la base de datos que es a  donde esta guardada la imagen 

                string rutaArchivo = Path.Combine(rutaCarpeta, nomArchivo);
                
                vm.Cabaña.Foto = nomArchivo;
  

                //Traigo el tipo que selecciono

                Tipo t = RepoTipo.FindById(vm.IdTipoSeleccionado);
                vm.Cabaña.Tipo = t;

                //RepoCabañas.Add(vm.Cabaña);
                AltaCabaña.Alta(vm.Cabaña);

                //Guardar la imagen
                FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
                vm.Foto.CopyTo(fs);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Oops! Ocurrió un error inesperado";               
                IEnumerable<Tipo> tipos = ListadoTipos.ObtenerListado();
                ViewBag.Tipos = tipos;
                return View(vm);                
            }
        }

         

        // GET: CabañasController
        public ActionResult EditCabaña(int Id)
        {

            HttpContext.Session.SetString("Menu", "no");
            Cabaña c = RepoCabañas.FindById(Id);

            return View(c);
        }


        // POST: CabañasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCabaña(int id, Cabaña c)
        {
            try
            {

                Cabaña aux = RepoCabañas.FindById(id);

                aux.Costo = c.Costo;
                aux.Nombre = c.Nombre;


               aux.Validar();
               RepoCabañas.Update(aux);
               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CabañasController/Delete/5
        public ActionResult DeleteCabaña(int Id)
        {
            HttpContext.Session.SetString("Menu", "no");
            Cabaña c = RepoCabañas.FindById(Id);
            
            return View(c);
        }

        // POST: CabañasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCabaña(Cabaña c, IFormCollection colletion)
        {
            
            try
            {

                EliminarCabaña.Eliminar(c.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Mensaje = "No se pudo eliminar la cabaña.";
                Cabaña ca = RepoCabañas.FindById(c.Id);
                return View(ca.Id);
            }
        }

        // GET: CabañaController/Details/
        public ActionResult Details(int id)
        {
            HttpContext.Session.SetString("Menu", "no");
            Cabaña c = RepoCabañas.FindById(id);
            return View(c);
           
        }



        // GET: CabañasController/Create
        public ActionResult CabañasPorCantMaxPersonas() {

            HttpContext.Session.SetString("Menu", "no");
            IEnumerable<Tipo> tipos = ListadoTipos.ObtenerListado();
            ViewBag.Tipos = tipos;

            return View(new List<Cabaña>());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST: CabañaController/Details/
        public ActionResult CabañasPorCantMaxPersonas(int MaxPersonas)
        {

            IEnumerable<Cabaña> cabañas = RepoCabañas.CabañasPorCantMaxPersonas(MaxPersonas);


            if (cabañas.Count() == 0)
            {
                ViewBag.Mensaje = "No hay cabañas disponibles para esta cantidad de personas";
            }
            return View(cabañas);
        }


        // GET: CabañasController/Create
        public ActionResult CabañasPorTexto()
        {

            return View(new List<Cabaña>());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: CabañaController/Details/
        public ActionResult CabañasPorTexto(string txt)
        {

            IEnumerable<Cabaña> cabañas = RepoCabañas.CabañasPorTexto(txt.Trim());

            if (cabañas.Count() == 0)
            {
                ViewBag.Mensaje = "No hay cabañas para la búsqueda realizada";
            }
            return View(cabañas);
            
        }



        // GET: CabañasController/Create
        public ActionResult CabañasHabilitadas()
        {
            IEnumerable<Cabaña> cabañas= RepoCabañas.CabañasHabilitadas();

            return View(cabañas);
        }



        // GET: CabañasController/Cabañas por tipo
        public ActionResult CabañasPorTipo()
        {

            HttpContext.Session.SetString("Menu", "no");
            IEnumerable<Tipo> tipos = ListadoTipos.ObtenerListado();
            ViewBag.Tipos = tipos;

            return View(new List<Cabaña>());
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: CabañaController/Details/
        public ActionResult CabañasPorTipo(int IdTipo)
        {
              
                IEnumerable<Cabaña> cabañas = RepoCabañas.CabañasPorTipo(IdTipo);
                IEnumerable<Tipo> tipos = ListadoTipos.ObtenerListado();
                ViewBag.Tipos = tipos;


                if (cabañas.Count() == 0)
                {
                    ViewBag.Mensaje = "No hay cabañas de este tipo para mostrar";
                }
                return View(cabañas);

        }




    }
}
