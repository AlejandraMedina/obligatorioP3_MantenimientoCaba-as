using Aplicacion.Interfacaces;
using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class BuscarTipoPorId : IBuscarTipoPorId
    {

        public IRepositorioTipos Repo { get; set; }

        public BuscarTipoPorId(IRepositorioTipos repo)
        {
            Repo = repo;
        }

        public TipoDTO Buscar(int id){

            TipoDTO dto = null;
            Tipo t = Repo.FindById(id);

            if (t != null) {

                dto = new TipoDTO()
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Descripcion = t.Descripcion,
                    Costo = t.Costo,
                };

            }

            return dto;

        }

        
    }
}
