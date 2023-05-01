using Datos.EF;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
                Contexto.Tipos.Add(obj);
                Contexto.SaveChanges();
            }

            public IEnumerable<Tipo> FindAll()
            {
                return Contexto.Tipos.ToList();
            }

            public Tipo FindById(int id)
            {
            Tipo buscado = Contexto.Tipos.Find(id);

            if (buscado == null)
            {
                throw new Exception("No existe el tipo con id " + id);
            }

            return buscado;
            }

            public void Remove(int id)
            {
                Tipo aBorrar = this.FindById(id);
                Contexto.Tipos.Remove(aBorrar);
                Contexto.SaveChanges();
            }

            public void Update(Tipo obj)
            {
            Contexto.Update(obj);
                Contexto.SaveChanges();
            }

            Tipo IRepositorio<Tipo>.FindById(int id)
            {
                Tipo buscado = Contexto.Tipos.Find(id);
                if(buscado == null)
                {
                    throw new Exception("No existe el tipo con id " + id);
                }

                return buscado;
            }
        }
}
