using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class EliminarCabaña : IEliminarCabaña
    {
        public IRepositorioCabañas Repo { get; set; }

        public EliminarCabaña(IRepositorioCabañas repo)
        {

            Repo = repo;
        }



        public void Eliminar(int id)
        {
            Repo.Remove(id);
        }

    }
}
