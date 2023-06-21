using Datos.EF;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Datos.Repositorios
{
    public class RepositorioMantenimientos : IRepositorioMantenimientos
    {
    

        public MantenimientoCabañaContext Contexto { get; set; }

        public RepositorioMantenimientos(MantenimientoCabañaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Mantenimiento obj)
        {
            //obj.Validar();
            Contexto.Mantenimientos.Add(obj);
            Contexto.SaveChanges();
        }

        public IEnumerable<Mantenimiento> FindAll()
        {
            return Contexto.Mantenimientos.ToList();
        }

        public Mantenimiento FindById(int id)
        {
            Mantenimiento buscado = Contexto.Mantenimientos.Find(id);

            if (buscado == null)
            {
                throw new Exception("No existe el tipo con id " + id);
            }

            return buscado;
        }

        public void Remove(int id)
        {
            Mantenimiento aBorrar = this.FindById(id);
            Contexto.Mantenimientos.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        public void Update(Tipo obj)
        {
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        

        public void Update(Mantenimiento obj)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Mantenimiento> MantenimientosPorCabañaPorFechas(DateTime inicio, DateTime fin, int id)
        {

                var mantenimientos = Contexto.Mantenimientos
                    .Where(mantenimiento => mantenimiento.Cabania.Id == id && mantenimiento.Fecha.Date >= inicio.Date && mantenimiento.Fecha.Date <= fin.Date ) 
                    .Select(mantenimiento => new Mantenimiento { 
                        Id = mantenimiento.Id,
                        Fecha = mantenimiento.Fecha,
                        Descripcion = mantenimiento.Descripcion,
                        Costo = mantenimiento.Costo,
                        Funcionario = mantenimiento.Funcionario,                       

                    }
                     )
                    .OrderByDescending(mantenimiento => mantenimiento.Costo)
                    .ToList();

                return mantenimientos;
        }

        public IEnumerable<Mantenimiento> MantenimientosPorCabaña (int id) 
        {
            var mantenimientos = Contexto.Mantenimientos
                        .Where(mantenimiento => mantenimiento.Cabania.Id == id)
                        .Select(mantenimiento => new Mantenimiento
                        {
                            Id = mantenimiento.Id,
                            Fecha = mantenimiento.Fecha,
                            Descripcion = mantenimiento.Descripcion,
                            Costo = mantenimiento.Costo,
                            Funcionario = mantenimiento.Funcionario
                        })
                        .ToList();

            return mantenimientos;
        }

        public IEnumerable<Mantenimiento> MantenimientosRealizados(int capMin, int capMax)
        {
            var mantenimientos = Contexto.Mantenimientos
                .Include(mantenimiento => mantenimiento.Cabania)
                .Where(mantenimiento => mantenimiento.Cabania.PersonasMax >= capMin && mantenimiento.Cabania.PersonasMax <= capMax)
                .GroupBy(mantenimiento => mantenimiento.Funcionario)
                .Select(mants => new Mantenimiento
                {
                    Funcionario = mants.Key,
                    Costo = mants.Sum(mantenimiento => mantenimiento.Costo)
                })
                .ToList();

            return mantenimientos;
        }

    }

}
