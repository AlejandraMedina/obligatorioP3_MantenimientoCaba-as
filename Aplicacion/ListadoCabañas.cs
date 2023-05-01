using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class ListadoCabaņas : IListadoCabaņas
    {
        public IRepositorioCabaņas Repo { get; set; }

        public ListadoCabaņas(IRepositorioCabaņas repo)
        {
            Repo = repo;
        }

        public IEnumerable<Cabaņa> ObtenerListado()
        {
            return Repo.FindAll();
        }

      
    }
}
