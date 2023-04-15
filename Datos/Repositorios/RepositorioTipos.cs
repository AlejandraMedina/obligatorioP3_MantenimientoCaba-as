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
    
        public class RepositorioTipos : IRepositorioTipos
        {

            public MantenimientoCabañaContext Contexto { get; set; }

            public RepositorioTipos(MantenimientoCabañaContext ctx)
            {
                Contexto = ctx;
            }

            public void Add(Tipo obj)
            {
                //obj.Validar();
               // Contexto.Tipo.Add(obj);
                Contexto.SaveChanges();
            }

            public IEnumerable<Tipo> FindAll()
            {
                return Contexto.Tipos.ToList();
            }

            public Tipo FindById(int id)
            {
                throw new NotImplementedException();
            }

            public void Remove(int id)
            {
               // Tipo aBorrar = this.FindById(id);
               // Contexto.Tipo.Remove(aBorrar);
                Contexto.SaveChanges();
            }

            public void Update(Tipo obj)
            {
                throw new NotImplementedException();
            }

            Tipo IRepositorio<Tipo>.FindById(int id)
            {
                throw new NotImplementedException();
            }
        }
}
