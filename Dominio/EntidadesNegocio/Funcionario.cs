using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Funcionario : Usuario
    {
   
        public Funcionario()
        {

        }

        public Funcionario(string email, string password) : base( email, password)
        {
        
        }

    }

}
