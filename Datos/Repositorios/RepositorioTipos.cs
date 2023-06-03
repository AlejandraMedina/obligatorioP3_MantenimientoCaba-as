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
using static System.Runtime.InteropServices.JavaScript.JSType;
using ExcepcionesPropias;

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
                throw new ErrorTipoException("No existe el tipo con id " + id);
            }           

            return buscado;
            }

            public void Remove(int id)
            {
                
                var buscadas = Contexto.Cabañas.Where(c => c.Tipo.Id == id).ToList();
                if (buscadas.Count() == 0) 
                {
                    Tipo tipo = FindById(id);
                    Contexto.Tipos.Remove(tipo);
                    Contexto.SaveChanges();
                    throw new Exception("El tipo fue eliminado con éxito");
                }

               
            }

            public void Update(Tipo obj)
            {
                Contexto.Update(obj);
                Contexto.SaveChanges();
            }


            //public Tipo BuscarTipoPorNombre(string nombre)   // VER TEMA DEL VALUE NO ANDA
            //{
            //    Tipo buscado = Contexto.Tipos.ToList().Where(t => t.Nombre.Value.Equals(nombre.Trim().ToLower()));

            //if (buscado == null)
            //{
            //    throw new Exception("No existe el tipo con nombre " + nombre);
            //}

            //return buscado;
            //}


         }
}
