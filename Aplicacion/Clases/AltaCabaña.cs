using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class AltaCaba�a : IAltaCaba�a
    {
        public IRepositorioCaba�as Repo { get; set; }

        public AltaCaba�a(IRepositorioCaba�as repo)
        {

            Repo = repo;
        }
        public void Alta(Caba�a c)
        {
            Repo.Add(c);
        }
    }
}
