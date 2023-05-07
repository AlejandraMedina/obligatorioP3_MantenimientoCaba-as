using Datos.EF;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        IEnumerable<Mantenimiento> IRepositorio<Mantenimiento>.FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Mantenimiento obj)
        {
            throw new NotImplementedException();
        }
    }
}
