﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;

namespace Datos
{
    public interface IRepositorioCabañas : IRepositorio<Cabaña>
    {
        //Dejo esto de guia aca va el metodo que tenga el repo
        //IEnumerable<Cabaña> CabañasConIncial(char inicial);
    }
}
