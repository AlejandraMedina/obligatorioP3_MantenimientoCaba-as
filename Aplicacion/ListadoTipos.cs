using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.InterfacesRepositorios;


namespace Aplicacion
{
    public class ListadoTipos : IListadoTipos
    {

        public IRepositorioTipos Repo { get; set; }

        public ListadoTipos(IRepositorioTipos repo)
        {
            Repo = repo;
        }

        public IEnumerable<Tipo> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
