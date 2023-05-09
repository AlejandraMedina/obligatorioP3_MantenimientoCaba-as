using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioMantenimientos : IRepositorio<Mantenimiento>
    {

        IEnumerable<Mantenimiento> MantenimientosPorCabañaPorFechas(DateTime inicio, DateTime fin, int id);
    }
}
