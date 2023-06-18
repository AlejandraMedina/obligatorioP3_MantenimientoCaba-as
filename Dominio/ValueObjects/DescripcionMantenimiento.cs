using Dominio.InterfacesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ValueObjects
{
    [Owned]
    public class DescripcionMantenimiento : IValidable
    {
        public string Value { get; private set; }
        public static int CantMaxCarDecripcionMantenimiento { get; set; }
        public static int CantMinCarDecripcionMantenimiento { get; set; }

        public DescripcionMantenimiento(string descrip) {
            Value = descrip;
            Validar();
        
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new Exception("La descripción no puede ser nula o vacía");
            }
            if (Value.Length < CantMinCarDecripcionMantenimiento)
            {
                throw new Exception("La descripción no puede tener menos de " + CantMinCarDecripcionMantenimiento);
            }
            if (Value.Length > CantMaxCarDecripcionMantenimiento)
            {
                throw new Exception("La descripción no puede tener más de " + CantMaxCarDecripcionMantenimiento);
            }
        }
    }
}
