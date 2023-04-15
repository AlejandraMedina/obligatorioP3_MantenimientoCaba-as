using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExcepcionesPropias
{
    public class NombreCabañaInvalidoException : Exception
    {
            
        public NombreCabañaInvalidoException() { }
        public NombreCabañaInvalidoException(string mensaje) {          
        }
        public NombreCabañaInvalidoException(string mensaje, Exception inner)  {
        }

    }

}
