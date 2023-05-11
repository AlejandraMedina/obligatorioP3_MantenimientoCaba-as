using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
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

        public IRepositorioUsuarios RepoUsuario { get; set; }


        public LoginUsuario(IRepositorioUsuarios repoUsuario) {

            RepoUsuario = repoUsuario;
        }
    

        public Usuario ExisteUsuario(string Email, string Password) {



            foreach (Usuario item in RepoUsuario.FindAll())
            {
                if (item.Email.Equals(Email.Trim()) && item.Password.Equals(Password.Trim()))
                {
                    return item;
                }
            }
            return null;

        }

       
    }
}
