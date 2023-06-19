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
    public class AltaCaba�a : IAltaCaba�a
    {
        public IRepositorioCaba�as Repo { get; set; }

        public AltaCaba�a(IRepositorioCaba�as repo)
        {

            Repo = repo;
        }
        public void Alta(Caba�aDTO c)
        {

            Caba�a caba�a = new Caba�a()
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
            Repo.Add(caba�a);
            c.Id = caba�a.Id;
        }       
        
    }
}
