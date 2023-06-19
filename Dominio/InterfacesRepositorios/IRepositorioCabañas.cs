using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;
using DTOs;

namespace Dominio.InterfacesRespositorios
{
    public interface IRepositorioCabañas : IRepositorio<Cabaña>
    {
      
        IEnumerable<Cabaña> CabañasPorTexto(string txt);

        IEnumerable<Cabaña> CabañasPorTipo(int tipo);

        IEnumerable<Cabaña> CabañasPorCantMaxPersonas(int cantMax);

        IEnumerable<Cabaña> CabañasHabilitadas();

    }
}
