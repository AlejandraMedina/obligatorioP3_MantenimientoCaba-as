using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public interface IListadoCabaņas
    {
        IEnumerable<Cabaņa> ObtenerListado();
    }
}