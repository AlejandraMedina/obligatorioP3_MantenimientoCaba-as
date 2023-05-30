using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 

namespace Aplicacion.Clases
{
    public class AltaTipo : IAltaTipo
    {
        public IRepositorioTipos Repo { get; set; }

        public AltaTipo(IRepositorioTipos repo)
        {

            Repo = repo;
        }
        public void Alta(TipoDTO t)
        {
            Tipo tipo = new Tipo();

           
      
        }

}
