using Dominio.InterfacesDominio;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Dominio.ValueObjects;

namespace Dominio.EntidadesNegocio
{


    //[Index(nameof(Nombre), IsUnique = true)]
    public class Cabaña : IValidable, IComparable<Cabaña>
    {

        public int Id { get; set; }
   
        [Required]
        //[RegularExpression(@"^[a-zA-Z]+$")]
        public string Nombre { get; set; }
    
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int NumHabitacion { get; set; }      
        
        public Tipo Tipo { get; set; }

      

        [StringLength(500, MinimumLength = 10)]

        public string Descripcion { get; set; }

        public bool Jacuzzi { get; set; }

        public bool Habilitada { get; set; }

        public int PersonasMax { get; set; }
        public string Foto { get; set; }
      

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
