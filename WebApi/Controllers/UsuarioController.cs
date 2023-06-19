using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    using Aplicacion.Interfaces;
    using DTOs;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    namespace WebApi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UsuariosController : ControllerBase
        {

            public ILoginUsuario LoginUsuario { get; set; }

            public UsuariosController(ILoginUsuario loginUsuario)
            {
                LoginUsuario = loginUsuario;
            }



            //api/usuarios/login POST
            [HttpPost("login")]
            public IActionResult Login([FromBody] UsuarioDTO usuario)
            {
                UsuarioDTO logueado = LoginUsuario.LoginUsuario(usuario.Email, usuario.Password);
                if (logueado == null) return Unauthorized("El usuario o la contraseña no son correctos ");
                return Ok(ManejadorJWT.GeneradorToken(logueado));
            }
        }
    }

}
