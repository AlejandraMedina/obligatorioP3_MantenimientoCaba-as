using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class NombreTipoException : ErrorTipoException
    {

        public NombreTipoException() { }

        public NombreTipoException(string msg) : base(msg) { }

        public NombreTipoException(string msg, Exception inner) : base(msg, inner) { }

    }
}
