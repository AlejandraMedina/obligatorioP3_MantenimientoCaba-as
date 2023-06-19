using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class LoginUsuario : ILoginUsuario
    {
        public IEnumerable<Usuario> usuarios;

        public IRepositorioUsuarios RepoUsuario { get; set; }


        public LoginUsuario(IRepositorioUsuarios repoUsuario)
        {

            RepoUsuario = repoUsuario;
        }



        UsuarioDTO ILoginUsuario.LoginUsuario(string mail, string Password)
        {

            UsuarioDTO dto = null;
            Usuario usu = RepoUsuario.Login(mail, Password);


            if (usu != null)
            {
                dto = new UsuarioDTO()
                {
                    Id = usu.Id,
                    Email = usu.Email,
                    Password = usu.Password
                };
            }
            return dto;

        }
    

        public Usuario ExisteUsuario(string Email, string Password)
        {



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
