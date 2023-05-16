using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dominio.EntidadesAuxiliares
{
    [Index(nameof(Descripcion), IsUnique = true)]
    public class Parametro
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public string  Valor {get; set;}
    }
}
