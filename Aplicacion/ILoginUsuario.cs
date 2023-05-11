using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;

namespace Aplicacion
{
    public interface ILoginUsuario   
    {
        public Usuario ExisteUsuario(string Email , string Password);
    }
}
