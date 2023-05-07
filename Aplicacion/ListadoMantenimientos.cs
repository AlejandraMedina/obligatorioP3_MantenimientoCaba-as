using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class ListadoMantenimientos : IListadoMantenimientos
    {
        public IRepositorioMantenimientos Repo { get; set; }

        public ListadoMantenimientos(IRepositorioMantenimientos repo)
        {
            Repo = repo;
        }

        public IEnumerable<Mantenimiento> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }

}
