using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Cabaña
    {
        public int id { get; set; }
        public string Nombre { get; }
        public int NumHabitacion { get; }
        public Tipo Tipo { get; set; }
        public float Costo { get; set; }
        public string Descripcion { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Habilitada { get; set; }
        public int PersonasMax { get; set; }
        public string Foto { get; set; }
        public int Mantenimiento { get; set; }
    }
}
