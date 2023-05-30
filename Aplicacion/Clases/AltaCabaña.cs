using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class AltaCabaña : IAltaCabaña
    {
        public IRepositorioCabañas Repo { get; set; }

        public AltaCabaña(IRepositorioCabañas repo)
        {

            Repo = repo;
        }
        public void Alta(Cabaña c)
        {
            Repo.Add(c);
        }
    }
}
