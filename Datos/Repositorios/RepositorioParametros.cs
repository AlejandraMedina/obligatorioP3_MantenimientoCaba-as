using Datos.EF;
using Dominio.EntidadesAuxiliares;
using Dominio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class RepositorioParametros :IRepositorioParametros
    {


        public MantenimientoCabañaContext Contexto { get; set; }

        public RepositorioParametros(MantenimientoCabañaContext ctx)
        {
            Contexto = ctx;
        }


        public void Add(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parametro> FindAll()
        {
            throw new NotImplementedException();
        }

        public Parametro FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public string CantMaxCarDescripcionMantenimiento(string descripcion) {

            return Contexto.Parametros
                           .Where(par => par.Descripcion == descripcion)
                           .Select(par => par.Valor)
                           .SingleOrDefault();
        }


        public string CantMinCarDescripcionMantenimiento(string descripcion) {
            return Contexto.Parametros
                            .Where(par => par.Descripcion == descripcion)
                            .Select(par => par.Valor)
                            .SingleOrDefault();
        }

     
    }
}
