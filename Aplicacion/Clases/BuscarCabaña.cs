using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class BuscarCabaña :IBuscarCabaña
    {

        public IRepositorio<Cabaña> Repo { get; set; }

        public BuscarCabaña(IRepositorio<Cabaña> repo)
        {
            Repo = repo;
        }

        public CabañaDTO BuscarPorId(int Id)
        {

            Cabaña cabaña = Repo.FindById(Id);

            if (cabaña != null)
            {

                return new CabañaDTO()
                {
                    Id = cabaña.Id,
                    TipoId = cabaña.TipoId,
                    Nombre = cabaña.Nombre,
                    Descripcion = cabaña.Descripcion,
                    NumHabitacion = cabaña.NumHabitacion,
                    Habilitada = cabaña.Habilitada,
                    Jacuzzi = cabaña.Jacuzzi,
                    //Foto = cabaña = cabaña.Foto, //VERR 
                    Tipo = new TipoDTO()
                    {
                        Id = cabaña.TipoId,
                        Nombre = cabaña.Tipo.Nombre,  //VER NO ME AGARRA EL Value del valid object
                        Descripcion = cabaña.Tipo.Descripcion,
                        Costo = cabaña.Tipo.Costo
                    }
                };
            }
            else 
            {
                return null;
            }
        }
    }
}
