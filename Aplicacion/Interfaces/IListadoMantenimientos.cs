﻿using Dominio.EntidadesNegocio;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IListadoMantenimientos
    {
        IEnumerable<MantenimientoDTO> ObtenerListado();
    }
}
