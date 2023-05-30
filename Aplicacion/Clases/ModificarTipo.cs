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
    public class ModificarTipo : IModificarTipo
    {

        public IRepositorioTipos Repo { get; set; }


        public ModificarTipo(IRepositorioTipos repo)
        {
            Repo = repo;
        }
        public void Modificar(Tipo t)
        {
            Repo.Update(t);

        }

        void IModificarTipo.ModificarTipo(Tipo t)
        {
            throw new NotImplementedException();
        }
    }
}
