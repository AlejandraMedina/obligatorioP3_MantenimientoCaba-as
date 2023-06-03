using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Aplicacion.Interfaces
{
    public interface IListadoTipos
    {
        IEnumerable<TipoDTO> ObtenerListado();

    }
}