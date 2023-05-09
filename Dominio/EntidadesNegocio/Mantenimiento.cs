using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public string Funcionario { get; set; }

        public Cabaña Cabania { get; set; }
        public int IdCabania { get; set; }
    }
}
