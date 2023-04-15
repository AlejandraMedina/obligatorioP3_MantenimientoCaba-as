using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExcepcionesPropias
{
    public class NombreTipoInvalidoException : Exception
    {

        public NombreTipoInvalidoException() { }
        public NombreTipoInvalidoException(string mensaje)
        {
        }
        public NombreTipoInvalidoException(string mensaje, Exception inner)
        {
        }
        
    }
}
