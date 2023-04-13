using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.EF;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;

namespace Datos.Repositorios
{
    public class RepositorioCabañas : IRepositorioCabañas 
    {

        public MantenimientoCabañaContext Contexto { get; set; }

        public RepositorioCabañas(MantenimientoCabañaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Cabaña obj)
        {
            obj.Validar();
            Contexto.Cabañas.Add(obj);
            Contexto.SaveChanges();
        }

        public IEnumerable<Cabaña> FindAll()
        {
            return Contexto.Cabañas.ToList();
        }

        public Cabaña FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            Cabaña aBorrar = this.FindById(id);
            Contexto.Cabañas.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        public void Update(Cabaña obj)
        {
            throw new NotImplementedException();
        }




    }
}
