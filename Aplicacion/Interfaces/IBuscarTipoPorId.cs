﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Aplicacion.Interfacaces
{
    public interface IBuscarTipoPorId
    {
        TipoDTO Buscar(int id);
      
    }
}
