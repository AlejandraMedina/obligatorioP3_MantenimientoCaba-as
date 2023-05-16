using Microsoft.EntityFrameworkCore;
using Dominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesAuxiliares;

namespace Datos.EF
{
    public class MantenimientoCabañaContext :DbContext
    {
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Cabaña>Cabañas { get; set; }       
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Parametro> Parametros { get; set; }
 
        public MantenimientoCabañaContext(DbContextOptions<MantenimientoCabañaContext> options):base(options)
        {

        }

    }
}
