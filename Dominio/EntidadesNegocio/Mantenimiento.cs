using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using Dominio.ExcepcionesPropias;

namespace Dominio.EntidadesNegocio
{
    [Index(nameof(Descripcion), IsUnique = true)]
    public class Mantenimiento
    {
        public static int CantMaxCarDecripcionMantenimiento { get; set; }
        public static int CantMinCarDecripcionMantenimiento { get; set; }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }


       // [StringLength(200, MinimumLength = 10)]
        [Required]
      //  [RegularExpression("@^[a-zA-Z]+$")]
        public string Descripcion { get; set; }

        [Range(0, double.MaxValue)]
        public double Costo { get; set; }

        [Required]
        public string Funcionario { get; set; }

        public Cabaña Cabania { get; set; }
        public int CabaniaId { get; set; }



        public void ValidarMantenimiento()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripción no puede ser nula o vacía");
            }
            if (Descripcion.Length < CantMinCarDecripcionMantenimiento)
            {
                throw new Exception("La descripción no puede tener menos de " + CantMinCarDecripcionMantenimiento);
            }
            if (Descripcion.Length > CantMaxCarDecripcionMantenimiento)
            {
                throw new Exception("La descripción no puede tener más de " + CantMaxCarDecripcionMantenimiento);
            }
        }

    }
}
