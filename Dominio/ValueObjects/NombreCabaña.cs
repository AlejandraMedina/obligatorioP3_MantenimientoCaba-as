using Dominio.InterfacesDominio;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio.ValueObjects
{
    public class NombreCabaña : IValidable
    {

        public string Value { get; private set; }
        public NombreCabaña(string nombre)
        {
            Value = nombre;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new NombreCabañaInvalidoException("El nombre no puede ser nulo o vacío");
            }
            if (Value.Length < 3)
            {
                throw new NombreCabañaInvalidoException("El nombre no puede tener menos de 3 caracteres");
            }
            if (Value.Length > 30)
            {
                throw new NombreCabañaInvalidoException("El nombre no puede tener más de 128 caracteres");
            }
        }
    }
}

