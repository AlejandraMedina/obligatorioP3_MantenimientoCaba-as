using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class ListadoMantenimientos : IListadoMantenimientos
    {
        public IRepositorioMantenimientos Repo { get; set; }

        public ListadoMantenimientos(IRepositorioMantenimientos repo)
        {
            Repo = repo;
        }

        public IEnumerable<MantenimientoDTO> ObtenerListado()
        {
            return Repo.FindAll().Select(m=> new MantenimientoDTO()
            {
                Id=m.Id,
                Fecha=m.Fecha,
                Descripcion = m.Descripcion,
                Costo=m.Costo,
                Funcionario =m.Funcionario,
                CabaniaId = m.CabaniaId

            });
        }
    }

}
