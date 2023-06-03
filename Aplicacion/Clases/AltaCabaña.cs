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
    public class AltaCabaņa : IAltaCabaņa
    {
        public IRepositorioCabaņas Repo { get; set; }

        public AltaCabaņa(IRepositorioCabaņas repo)
        {

            Repo = repo;
        }
        public void Alta(Cabaņa c)
        {
            Repo.Add(c);
        }
    }
}
