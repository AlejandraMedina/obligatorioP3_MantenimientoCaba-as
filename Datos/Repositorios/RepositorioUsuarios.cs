using Datos.EF;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorios;
using Dominio.InterfacesRespositorios;

namespace Datos.Repositorios
{
    public class RepositorioUsuarios: IRepositorioUsuarios
    {

        public MantenimientoCabañaContext Contexto { get; set; }

        public RepositorioUsuarios(MantenimientoCabañaContext ctx)
        {
            Contexto = ctx;
        }

    }


}
