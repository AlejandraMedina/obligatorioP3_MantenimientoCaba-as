using Dominio.EntidadesNegocio;

namespace PresentacionMVC.Models
{
    public class AltaTipoViewModel
    {
        public Tipo tipo { get; set; }
        public IEnumerable<Tipo> Tipos { get; set; }
    }
}
