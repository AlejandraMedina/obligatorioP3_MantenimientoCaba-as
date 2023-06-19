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
    public class BuscarMantenimientoPorId : IBuscarMantenimientoPorId
    {

        public IRepositorioMantenimientos RepoMant { get; set; }



        public BuscarMantenimientoPorId(IRepositorioMantenimientos repoMant)
        {

            RepoMant = repoMant;
            
        }
        public MantenimientoDTO BuscarMant(int id)
        {
            Mantenimiento m = RepoMant.FindById(id);
            MantenimientoDTO mantdto = new MantenimientoDTO()
            {
                Fecha = m.Fecha,
                Descripcion = m.Descripcion,
                //Descripcion = new DescripcionMantenimiento(m.Descripcion),
                Costo = m.Costo,
                Funcionario = m.Funcionario,
                CabaniaId = m.CabaniaId,

            };
            return mantdto;
        }
    }
}
