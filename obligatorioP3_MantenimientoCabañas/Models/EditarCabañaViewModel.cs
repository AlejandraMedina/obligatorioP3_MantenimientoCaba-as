using Dominio.EntidadesNegocio;

namespace PresentacionMVC.Models
{
    public class EditarCabañaViewModel
    {
        
        public int Id { get; set; }
        public Cabaña Cabaña { get; set; }
        public IEnumerable<Tipo> Tipos { get; set; }

        public int IdTipoSeleccionado { get; set; }
        public IFormFile Foto { get; set; }

    }

}
