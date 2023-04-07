using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class ListadoCaba�as : IListadoCaba�as
    {
        public IRepositorioCaba�as Repo { get; set; }

        public ListadoCaba�as(IRepositorioCaba�as repo)
        {
            Repo = repo;
        }

        public IEnumerable<Caba�a> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
