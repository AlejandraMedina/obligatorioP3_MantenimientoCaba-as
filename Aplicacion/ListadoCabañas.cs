using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class ListadoCabañas : IListadoCabañas
    {
        public IRepositorioCabañas Repo { get; set; }

        public ListadoCabañas(IRepositorioCabañas repo)
        {
            Repo = repo;
        }

        public IEnumerable<Cabaña> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
