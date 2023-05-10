using Dominio.EntidadesNegocio;

namespace PresentacionMVC.Models
{
  
        public class AltaCabañaViewModel
        {
            public int Id { get; set; }
            public Cabaña Cabaña { get; set; }

            public IEnumerable<Tipo> Tipos { get; set; }

            public int IdTipoSeleccionado { get; set; }

            public IFormFile Foto { get; set; }

        }
    
}
