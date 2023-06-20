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
    public class ListadoCaba�as : IListadoCaba�as
    {
        public IRepositorioCaba�as Repo { get; set; }

        public ListadoCaba�as(IRepositorioCaba�as repo)
        {
            Repo = repo;
        }

       

        public IEnumerable<Caba�aDTO> ObtenerListado()
        {
            IEnumerable<Caba�a> caba�as  = Repo.FindAll().OfType <Caba�a>();

            return caba�as.Select(caba�a => new Caba�aDTO()
            {
                Id = caba�a.Id,
                TipoId = caba�a.TipoId,
                Nombre = caba�a.Nombre,
                Descripcion = caba�a.Descripcion,
                NumHabitacion = caba�a.NumHabitacion,
                Habilitada = caba�a.Habilitada,
                Jacuzzi = caba�a.Jacuzzi,
                Foto =  caba�a.Foto, //VERR 
                Tipo = new TipoDTO() { 
                Id = caba�a.TipoId,
                Nombre = caba�a.Tipo.Nombre,  //VER NO ME AGARRA EL Value del valid object
                Descripcion = caba�a.Tipo.Descripcion,
                Costo = caba�a.Tipo.Costo              
                }
            });
        }


    }
}
