using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class LoginUsuario : ILoginUsuario
    {
        public IEnumerable<Usuario> usuarios;

        public Usuario ExiteUsuario(string Email) {

            foreach (Usuario item in usuarios)
            {
                if (item.Equals(Email))
                {
                    return item;
                }
            }
            return null;

        }

       
    }
}
