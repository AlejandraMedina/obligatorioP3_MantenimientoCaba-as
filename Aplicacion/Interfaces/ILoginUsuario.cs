using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Clases;
using Dominio.EntidadesNegocio;
using DTOs;

namespace Aplicacion.Interfaces
{
    public interface ILoginUsuario
    {
        UsuarioDTO LoginUsuario(string Email,  string Password);
        
        public Usuario ExisteUsuario(string Email, string Password);
    }
}
