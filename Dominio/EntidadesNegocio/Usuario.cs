using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;



namespace Dominio.EntidadesNegocio
{
    public class Usuario 
           
    {
        
        public int Id { get; set; }

        static int UltIdUsuario;

        //[Index(IsUnique = true)]
        [Required]
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
            //SoloLetrasYNumeros(contrasenia);
        }


        public void ValidarEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("Se recibió email sin datos.");
            }
            if (Email.Length < 6)
            {
                throw new Exception("El nombre de usuario debe contener al menos 6 caracteres.");
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
            if (Password.Length < 6)
            {
                throw new Exception("La contraseña debe contener al menos 6 caracteres.");
            }
        }

        public bool Equals([AllowNull] Usuario other)
        {
           
            return (Email.Equals(other.Email) && Password.Equals(other.Password));
        }

        
        
         public void SoloLetrasYNumeros(string contrasenia)                {                   

                 if (!Regex.IsMatch(contrasenia, "^(?=.*[A-Z])(?=.*[0-9])(?=.*[a-z]).{6,}$"))
                 {
                 throw new Exception("La contraseña debe contener al menos una minuscula, una mayúscula y un número");
                 }
                
          }
        

    }

}
