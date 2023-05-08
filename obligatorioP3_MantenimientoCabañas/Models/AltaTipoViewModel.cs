using Dominio.EntidadesNegocio;

namespace PresentacionMVC.Models
{
    public class AltaTipoViewModel
    {
        //public int Id { get; set; }
        public Tipo Tipo { get; set; }
        public IEnumerable<Tipo> Tipos { get; set; }
    }
}
