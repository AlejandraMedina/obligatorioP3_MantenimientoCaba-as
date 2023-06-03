﻿using Aplicacion.Interfaces;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Clases
{
    public class AltaMantenimiento : IAltaMantenimiento
    {
        public IRepositorioMantenimientos Repo { get; set; }


        public IRepositorioParametros RepoParams { get; set; }


        public AltaMantenimiento(IRepositorioMantenimientos repo, IRepositorioParametros repoParams)
        {

            Repo = repo;
            RepoParams = repoParams;
        }
        public void Alta(MantenimientoDTO m)
        {
            Mantenimiento.CantMaxCarDecripcionMantenimiento = int.Parse(RepoParams.CantMaxCarDescripcionMantenimiento("CantMaxCarDescripcionMantenimiento"));
            Mantenimiento.CantMinCarDecripcionMantenimiento = int.Parse(RepoParams.CantMinCarDescripcionMantenimiento("CantMinCarDescripcionMantenimiento"));
            m.ValidarMantenimiento();
           // Repo.Add(m);
        }

        public void Alta(Mantenimiento m)
        {
            throw new NotImplementedException();
        }
    }
}