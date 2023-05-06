using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public abstract class Usuario 
    {
       
        public string Mail { get; set; }
        public string Password { get; set; }

        public int Id { get; private set; }

        private static int numId = 1;



        public Usuario()
        {
            Id = numId;
        }

        public Usuario(string mail, string password)
        {
            Id = numId++;
            Mail = mail;
            Password = password;
        }



        public override bool Equals(object obj)
        {
            Usuario unU = obj as Usuario;
            return Mail == unU.Mail;
        }

        public override int GetHashCode()
        {
            return Id;
        }

    }




}
