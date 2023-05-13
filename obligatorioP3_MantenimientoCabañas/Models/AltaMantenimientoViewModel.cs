using Dominio.EntidadesNegocio;

namespace PresentacionMVC.Models
{
    public class AltaMantenimientoViewModel
    {
        public int Id { get; set; }
        public Mantenimiento Mantenimiento { get; set; }

        public int IdCabañaSeleccionada { get; set; }
        public Cabaña Cabaña { get; set; }

        public int CabañaId { get; set; }

    }
}
