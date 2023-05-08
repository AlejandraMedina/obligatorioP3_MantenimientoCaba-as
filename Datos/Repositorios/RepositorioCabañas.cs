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
            return Contexto.Cabañas.ToList();
        }

        public Cabaña FindById(int id)
        {

            Cabaña buscada = Contexto.Cabañas.Find(id);


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
            throw new NotImplementedException();
        }

    //    public IEnumerable<Cabaña> CabañaPorTexto(string txt)


    //    {
    //        {
    //            var cabañas = Contexto.Cabañas
    //                .Where(cabaña => cabaña.Nombre.Contains(txt))
    //                .Select(cabaña=> new Cabaña
    //                {
    //                    Id=cabaña.Id,        
    //                    Nombre=cabaña.Nombre,
    //                    NumHabitacion=cabaña.NumHabitacion,
    //                    CantMaxPersonas=cabaña.CantMaxPersonas,

    //                    Tipo = new Tipo
    //                    {
    //                        Id=cabaña.Tipo.Id,
    //                        Nombre=cabaña.Tipo.Nombre,
    //                        Descripcion=cabaña.Tipo.Descripcion,
    //    },
    //                    Costo=cabaña.Costo,
    //                    Descripcion=cabaña.Descripcion,
    //                    Jacuzzi=cabaña.Jacuzzi,
    //                    Habilitada=cabaña.Habilitada,
      
    //                    //Foto=cabaña.Foto,
        
    //}
    //                )
    //                                             .ToList();

    //            return cabañas.ToList();
    //        }

    //    }

        //IEnumerable<Cabaña> CabañasPorTipo(Tipo tipo)
        //{
        //    throw new NotImplementedException();

        //}

        

        public IEnumerable<Cabaña> CabañasPorCantMaxPersonas(int cantMax)
        {
            
                var cabañas = Contexto.Cabañas
                                      .Include(cabaña => cabaña.Tipo)
                                      .ThenInclude(Tipo => Tipo.Nombre)
                                      .Where(cabaña => cabaña.PersonasMax == cantMax)
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
                                      }
                                      )
                                     .ToList();
                return cabañas;
           
        }

        //IEnumerable<Cabaña> CabañasHabilitadas()
        //{
        //    var cabañas = Contexto.Cabañas.Where(cabaña => cabaña.Habilitada == true);

        //    var habilitadas = Contexto.Cabañas
        //                    .Select(cabaña => cabaña.Nombre)
        //                    .ToList();

        //    return cabañas.ToList();
        //}
    }
}
