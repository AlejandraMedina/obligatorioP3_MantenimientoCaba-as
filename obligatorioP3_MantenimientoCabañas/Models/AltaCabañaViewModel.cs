using Dominio.EntidadesNegocio;

namespace PresentacionMVC.Models
{
  
        public class AltaCabañaViewModel
        {
            public Cabaña cabaña { get; set; }
            public List<Tipo> tipos { get; set; }
            public int IdTipoSeleccionado { get; set; }

    }
    
}
