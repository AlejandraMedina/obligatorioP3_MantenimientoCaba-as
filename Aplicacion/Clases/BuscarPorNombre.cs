using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Aplicacion.Clases
{
    public class BuscarPorNombre : IBuscarPorNombre
    { 


        public IRepositorioTipos Repo { get; set; }

        public BuscarPorNombre(IRepositorioTipos repo)
        {

            Repo = repo;
        }



        public TipoDTO Buscar(string nombre)
        {
            Tipo tipo Repo.BuscarTipoPorNombre(nombre);  // ACA NO RECONOCE EL SELECT
            {
                Id = t.Id,
                Nombre = t.Nombre.Value,
                Descripcion = t.Descripcion,
                Costo = t.Costo
            });

        }
    }
}
