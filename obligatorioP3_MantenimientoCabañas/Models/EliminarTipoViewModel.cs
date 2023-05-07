using Dominio.EntidadesNegocio;

namespace PresentacionMVC.Models
{
    public class EliminarTipoViewModel
    {
        public int Id { get; set; }
        public Tipo Tipo { get; set; }
        public IEnumerable<Tipo> Tipos { get; set; }
    }
}
