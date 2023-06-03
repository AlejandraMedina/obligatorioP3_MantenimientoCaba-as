using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Aplicacion.Clases
{
    public class ModificarTipo : IModificarTipo
    {

        public IRepositorioTipos Repo { get; set; }
       


        public ModificarTipo(IRepositorioTipos repo)
        {
            Repo = repo;
        }


        public void Modificar(TipoDTO t)
        {

            Tipo aMofificar = new Tipo()
            {
                Id= t.Id,
                Nombre = t.Nombre,
                Descripcion = t.Descripcion,
                Costo = t.Costo
            };
            Repo.Update(aMofificar);               

        }      
    }
}
