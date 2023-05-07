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
    public class AltaMantenimiento : IAltaMantenimiento
    {
        public IRepositorioMantenimientos Repo { get; set; }

        public AltaMantenimiento(IRepositorioMantenimientos repo)
        {

            Repo = repo;
        }
        public void Alta(Mantenimiento m)
        {
            Repo.Add(m);
        }
    }
}
