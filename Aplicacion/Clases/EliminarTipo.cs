using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class EliminarTipo : IEliminarTipo
    {
        public IRepositorioTipos Repo { get; set; }

        public EliminarTipo(IRepositorioTipos repo)
        {

            Repo = repo;
        }


        public void Remove(int id)
        {
            Repo.Remove(id);
        }
    }

}
