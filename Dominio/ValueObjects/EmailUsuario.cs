using Dominio.InterfacesDominio;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObjects
{
    public class EmailUsuario
    {
        public string Value { get; private set; }
        public EmailUsuario(string nombre)
        {
            Value = nombre;
            Validar();
        }

       
        void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new Exception("Se recibió email sin datos.");
            }
            if (Value.Length < 6)
            {
                throw new Exception("El nombre de usuario debe contener al menos 6 caracteres.");
            }
            if (!(Value.Contains("@")))
            {
                throw new Exception("No se ingresó un mail válido.");
            }
            if (Value.Substring(0, 1).Contains("@") || Value.Substring(Value.Length - 1).Contains("@"))
            {
                throw new Exception("No se ingresó un formato de mail correcto.");
            }
        }
    }
}
