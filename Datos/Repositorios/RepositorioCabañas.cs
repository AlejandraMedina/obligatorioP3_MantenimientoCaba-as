using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.EF;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using Dominio.ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;

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
            return Contexto.Cabañas.Include(c => c.Tipo).ToList();

        }

        public Cabaña FindById(int id)
        {

            Cabaña buscada = Contexto.Cabañas.Include(c => c.Tipo)
                           .Where(c => c.Id == id)
                           .SingleOrDefault();


            if (buscada == null)
            {
                throw new Exception("No existe la cabaña con id " + id);
            }

            return buscada;
        }

        public void Remove(int id)
        {
            Cabaña aBorrar = this.FindById(id);
            Contexto.Cabañas.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        public void Update(Cabaña obj)
        {
            Contexto.Update(obj);            
            Contexto.SaveChanges();
        }



        public IEnumerable<Cabaña> CabañasPorTexto(string txt)
        {
            
                var cabañas = Contexto.Cabañas
                    .Where(cabaña => cabaña.Nombre.Contains(txt))
                    .Select(cabaña => new Cabaña
                    {
                        Id = cabaña.Id,
                        Nombre = cabaña.Nombre,
                        NumHabitacion = cabaña.NumHabitacion,
                        PersonasMax = cabaña.PersonasMax,

                        Tipo = new Tipo
                        {
                            Id = cabaña.Tipo.Id,
                            Nombre = cabaña.Tipo.Nombre,
                            Descripcion = cabaña.Tipo.Descripcion,
                        },
                        Costo = cabaña.Costo,
                        Descripcion = cabaña.Descripcion,
                        Jacuzzi = cabaña.Jacuzzi,
                        Habilitada = cabaña.Habilitada,
                        Foto=cabaña.Foto,

                    }
                    )
                    .ToList();

                return cabañas;
            

        }

        public IEnumerable<Cabaña> CabañasPorTipo(int idTipo)
        {
            var cabañas = Contexto.Cabañas
                                      .Include(cabaña => cabaña.Tipo)                                      
                                      .Where(cabaña => cabaña.Tipo.Id == idTipo)
                                      .Select(cabaña => new Cabaña
                                      {
                                          Id = cabaña.Id,
                                          Nombre = cabaña.Nombre,
                                          NumHabitacion = cabaña.NumHabitacion,
                                          PersonasMax = cabaña.PersonasMax,
                                          Costo = cabaña.Costo,
                                          Descripcion = cabaña.Descripcion,
                                          Jacuzzi = cabaña.Jacuzzi,
                                          Habilitada = cabaña.Habilitada,
                                          Foto = cabaña.Foto,
                                          Tipo = new Tipo { Id = cabaña.Tipo.Id, Nombre = cabaña.Tipo.Nombre }
                                      }
                                      )
                                     .ToList();

            return cabañas;

        }



        public IEnumerable<Cabaña> CabañasPorCantMaxPersonas(int cantMax)
        {

            var cabañas = Contexto.Cabañas
                                  .Include(cabaña => cabaña.Tipo)                                  
                                      .Where(cabaña => cabaña.PersonasMax >= cantMax)
                                      .Select(cabaña => new Cabaña
                                      {
                                          Id = cabaña.Id,
                                          Nombre = cabaña.Nombre,
                                          NumHabitacion = cabaña.NumHabitacion,
                                          PersonasMax = cabaña.PersonasMax,
                                          Costo = cabaña.Costo,
                                          Descripcion = cabaña.Descripcion,
                                          Jacuzzi = cabaña.Jacuzzi,
                                          Habilitada = cabaña.Habilitada,
                                          Foto = cabaña.Foto,
                                          Tipo = new Tipo { Id = cabaña.Tipo.Id, Nombre = cabaña.Tipo.Nombre }
                                      }
                                      ) 
                                     .ToList();
                return cabañas;
           
        }


        public IEnumerable<Cabaña> CabañasHabilitadas()
        {
            var cabañas = Contexto.Cabañas.Where(cabaña => cabaña.Habilitada == true);          
                          
            return cabañas.ToList();
        }
    }
}
