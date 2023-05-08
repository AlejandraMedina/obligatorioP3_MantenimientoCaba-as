using Aplicacion;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentacionMVC.Controllers
{
    public class UsuarioController : Controller
    {


        ILoginUsuario LoginUsuario { get; set; }

        IListadoUsuarios listadoUsuarios { get; set; }




        public UsuarioController(ILoginUsuario loginUsuario, IListadoUsuarios listadoUsuarios)
        {
            LoginUsuario = loginUsuario;
           
        }

        // GET: UsuarioController
        public ActionResult Login()
        {
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string EMail, string Password)
        {
            
            try
            {

                LoginUsuario.ExiteUsuario(EMail, Password);

                HttpContext.Session.SetString("usuarioLogueado","si");

                return RedirectToAction("Index","Home");

            }
            catch (Exception e)
            {
                ViewBag.Mensaje = "Nombre de usuario o contraseña incorrectos";
                return RedirectToAction("login");
            }          

         
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("usurioLogueado", "no");
            return RedirectToAction("login");
        }

     }
}
