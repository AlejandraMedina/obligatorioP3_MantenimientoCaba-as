﻿using Dominio.EntidadesNegocio;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IModificarTipo
    {
        void Modificar(TipoDTO tipo);

    }
}
