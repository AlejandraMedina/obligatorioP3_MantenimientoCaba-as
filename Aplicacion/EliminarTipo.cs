using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class EliminarTipo : IEliminarTipo
    {
        public IRepositorioTipos Repo { get; set; }

        public EliminarTipo(IRepositorioTipos repo)
        {

            Repo = repo;
        }
        public void Eliminar(int t)
        {
            Repo.Remove(t);
        }

        public void Remove(int t)
        {
            throw new NotImplementedException();
        }
    }

}
