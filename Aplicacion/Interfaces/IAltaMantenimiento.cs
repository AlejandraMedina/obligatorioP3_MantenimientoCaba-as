using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IAltaMantenimiento
    {
        void Alta(MantenimientoDTO m);
    }
}
