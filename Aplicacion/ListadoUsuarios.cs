using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class ListadoUsuarios : IListadoUsuarios
    {
        public IRepositorioUsuarios Repo { get; set; }

        public ListadoUsuarios(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }

        public IEnumerable<Usuario> ObtenerListado()
        {
            return Repo.FindAll();
        }

    }
}
