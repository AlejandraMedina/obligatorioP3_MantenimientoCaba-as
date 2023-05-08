using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Usuario 
           
    {
        
        public int Id { get; set; }

        static int UltIdUsuario;

        public string Email { get; set; }

        public string Password { get; set; }

 


        public Usuario()
        {
            Id = UltIdUsuario++;
        }
      


        public void Validar()
        {
            ValidarEmail();
            ValidarPassword();
        }


        public void ValidarEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("Se recibió email sin datos.");
            }
            if (!(Email.Contains("@")))
            {
                throw new Exception("No se ingresó un mail válido.");
            }
            if (Email.Substring(0, 1).Contains("@") || Email.Substring(Email.Length - 1).Contains("@"))
            {
                throw new Exception("No se ingresó un formato de mail correcto.");
            }
        }
        public void ValidarPassword()
        {
            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("Se recibió password sin datos.");
            }
            if (Password.Length < 8)
            {
                throw new Exception("La contraseña debe contener al menos 8 caracteres.");
            }
        }

        public bool Equals([AllowNull] Usuario other)
        {
            // TODO: es necesario comparar tambien la contraseña?
            return (Email.Equals(other.Email) && Password.Equals(other.Password));
        }



    }

}
