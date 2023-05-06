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
            if (HttpContext.Session.GetString("rol") == "funcionario")
            {
                return Redirect("/home/index");
            }
            HttpContext.Session.SetString("rol", "sinIdentificar");
           // ViewBag.Error = error;
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string EMail)
        {
            if (HttpContext.Session.GetString("rol") == "funcionario")
            {
                return Redirect("/home/index");
            }
            try
            {
                if (string.IsNullOrEmpty(EMail))
                {
                    return RedirectToAction("login", new { error = "Por favor completar ambos campos." });
                }

                Usuario usuario = LoginUsuario.ExiteUsuario(EMail);

                if (usuario == null)
                {
                    return RedirectToAction("login", new { error = "Usuario y/o contraseña incorrectos." });
                }

                HttpContext.Session.SetString("email", EMail);
                HttpContext.Session.SetInt32("idUsuario", usuario.Id);
              

                if (usuario.Rol == "funcionario")
                {
                    HttpContext.Session.SetString("rol", "funcionario");
                }
               
                return Redirect("/home/index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return RedirectToAction("login");
            }          

         
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("rol", "sinIdentificar");
            return RedirectToAction("login");
        }

       }
}
