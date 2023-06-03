using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObjects
{
    public class NombreTipo
    {
        public string Value { get; private set; }
        public NombreTipo(string nombre)
        {
            Value = nombre;
            //Validar();  //Si hubiese alguna validación para el monbre

        }
    }
}
