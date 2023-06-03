using Dominio.EntidadesNegocio;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IAltaTipo
    {
        void Alta(TipoDTO t);
    }
}
