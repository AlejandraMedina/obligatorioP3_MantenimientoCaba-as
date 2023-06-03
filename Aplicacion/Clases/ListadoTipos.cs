using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.InterfacesRepositorios;
using Aplicacion.Interfaces;
using DTOs;
using ExcepcionesPropias;

namespace Aplicacion.Clases
{
    public class ListadoTipos : Interfaces.IListadoTipos
    {

        public IRepositorioTipos Repo { get; set; }

        public ListadoTipos(IRepositorioTipos repo)
        {
            Repo = repo;
        }

        public IEnumerable<TipoDTO> ObtenerListado()
        {
            return Repo.FindAll().Select (T => new TipoDTO() { 
            Id = T.Id,
            Nombre = T.Nombre,
            Descripcion = T.Descripcion,
            Costo = T.Costo            
            });
        }
    }
}
