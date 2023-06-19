using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRespositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class AltaCabaña : IAltaCabaña
    {
        public IRepositorioCabañas Repo { get; set; }

        public AltaCabaña(IRepositorioCabañas repo)
        {

            Repo = repo;
        }
        public void Alta(CabañaDTO c)
        {

            Cabaña cabaña = new Cabaña()
            {
                Id = 0,
                Nombre = c.Nombre,

                NumHabitacion = c.NumHabitacion,

                //Tipipo,

                Descripcion = c.Descripcion,

                Jacuzzi = c.Jacuzzi,

                Habilitada = c.Habilitada,

                PersonasMax = c.PersonasMax,

                TipoId = c.TipoId,

                Foto = c.Foto
            };
            Repo.Add(cabaña);
            c.Id = cabaña.Id;
        }       
        
    }
}
