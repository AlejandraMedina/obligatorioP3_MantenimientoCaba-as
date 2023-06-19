using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTOs
{
    public class CabañaDTO
    {

        public int Id { get; set; }

        [Required]
        //[RegularExpression(@"^[a-zA-Z]+$")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }


        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int NumHabitacion { get; set; }

        public int TipoId { get; set; }

        public TipoDTO Tipo { get; set; }


        [StringLength(500, MinimumLength = 10)]

       
        public bool Jacuzzi { get; set; }

        public bool Habilitada { get; set; }

        public int PersonasMax { get; set; }
        public string Foto { get; set; }

    }
}
