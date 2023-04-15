using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using Aplicacion;
using Dominio.ExcepcionesPropias;
using PresentacionMVC.Models;
using System.Globalization;

namespace PresentacionMVC.Controllers
{
    public class CabañaController : Controller
    {

        public IListadoTipos ListadoTipos { get; set; }

        public IRepositorio<Cabaña> RepoCabañas { get; set; }


       

        public IWebHostEnvironment WHE { get; set; }

        public CabañaController(IListadoTipos listadoTipos, IRepositorio<Cabaña> repo, IWebHostEnvironment whe)
        {
            ListadoTipos = listadoTipos;
            RepoCabañas = repo;
            WHE = whe;      
        }


        //IListadoCabañas ListadoCabañas { get; set; }

        //IAltaCabaña AltaCabaña{ get; set; }


       // public CabañaController(IListadoCabañas listadoCabañas, IAltaCabaña altaCabaña)
        //{
         //   ListadoCabañas = listadoCabañas;
          //  AltaCabaña = altaCabaña;
        //}


        // GET: CabañasController
        public ActionResult Index()
        {
            IEnumerable<Cabaña> cabañas = RepoCabañas.FindAll();
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
           //Para que se carguen los tipos de cabaña en el desplegable de la vista inicial
            AltaCabañaViewModel vm = new AltaCabañaViewModel();
            
            vm.Tipos = ListadoTipos.ObtenerListado().ToList();
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

                //vm.Cabaña.Tipo.id = vm.IdTipoSeleccionado;
                vm.Cabaña.Foto = nomArchivo;

                RepoCabañas.Add(vm.Cabaña);
                //Guardar la imagen

                FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
                vm.Foto.CopyTo(fs);

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
            Cabaña c = RepoCabañas.FindById(id);
            return View(c);           
        }
    }
}
