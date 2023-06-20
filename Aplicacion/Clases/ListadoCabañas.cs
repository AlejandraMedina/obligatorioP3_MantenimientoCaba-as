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
    public class ListadoCabañas : IListadoCabañas
    {
        public IRepositorioCabañas Repo { get; set; }

        public ListadoCabañas(IRepositorioCabañas repo)
        {
            Repo = repo;
        }

       

        public IEnumerable<CabañaDTO> ObtenerListado()
        {
            IEnumerable<Cabaña> cabañas  = Repo.FindAll().OfType <Cabaña>();

            return cabañas.Select(cabaña => new CabañaDTO()
            {
                Id = cabaña.Id,
                TipoId = cabaña.TipoId,
                Nombre = cabaña.Nombre,
                Descripcion = cabaña.Descripcion,
                NumHabitacion = cabaña.NumHabitacion,
                Habilitada = cabaña.Habilitada,
                Jacuzzi = cabaña.Jacuzzi,
                //Foto = cabaña = cabaña.Foto, //VERR 
                Tipo = new TipoDTO() { 
                Id = cabaña.TipoId,
                Nombre = cabaña.Tipo.Nombre,  //VER NO ME AGARRA EL Value del valid object
                Descripcion = cabaña.Tipo.Descripcion,
                Costo = cabaña.Tipo.Costo              
                }
            });
        }


    }
}
