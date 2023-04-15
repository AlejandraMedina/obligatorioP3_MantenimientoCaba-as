using Dominio.InterfacesDominio;
using Dominio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.EntidadesNegocio
{
    public class Cabaña : IValidable , IComparable<Cabaña>
    {
        public int Id { get; set; }

        [Key]
        public  string Nombre { get; set; }
        public int NumHabitacion { get; set; }
        public Tipo Tipo { get; set; }
        public float Costo { get; set; }
        public string Descripcion { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Habilitada { get; set; }
        public int PersonasMax { get; set; }
        public string Foto { get; set; }
        public int Mantenimiento { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new NombreCabañaInvalidoException("El nombre no puede ser nulo o vacío");
            }
            if (Nombre.Length < 3)
            {
                throw new NombreCabañaInvalidoException("El nombre no puede tener menos de 3 caracteres");
            }
            if (Nombre.Length > 30)
            {
                throw new NombreCabañaInvalidoException("El nombre no puede tener más de 128 caracteres");
            }
        }


        public int CompareTo(Cabaña other)
        {
            throw new NotImplementedException();
        }
    }
}
