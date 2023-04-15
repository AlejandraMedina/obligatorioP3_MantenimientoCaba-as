using Dominio.EntidadesNegocio;

namespace PresentacionMVC.Models
{
  
        public class AltaCabañaViewModel
        {
            public Cabaña Cabaña { get; set; }
            public List<Tipo> Tipos { get; set; }
            public int IdTipoSeleccionado { get; set; }
            public IFormFile Foto { get; set; }

        }
    
}
