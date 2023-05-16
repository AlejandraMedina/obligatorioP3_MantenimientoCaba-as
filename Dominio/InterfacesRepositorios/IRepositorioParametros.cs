using Dominio.EntidadesAuxiliares;
using Dominio.InterfacesRespositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioParametros : IRepositorio<Parametro>
    {
        string CantMaxCarDescripcionMantenimiento(string descripcion);
        string CantMinCarDescripcionMantenimiento(string descripcion);
 
    }
}
