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


        public void Add(Usuario obj)
        {
            //obj.Validar();
            Contexto.Usuarios.Add(obj);
            Contexto.SaveChanges();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            Usuario buscado = Contexto.Usuarios.Find(id);

            if (buscado == null)
            {
                throw new Exception("No existe el usuarioo con id " + id);
            }

            return buscado;
        }

        public void Remove(int id)
        {
            Usuario aBorrar = this.FindById(id);
            //ContextoUsuarios.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        public void Update(Usuario obj)
        {
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }


        public Usuario ExiteUsuario(string Email, string Password)
        {

            foreach (Usuario item in Contexto.Usuarios)
            {
                if (item.Email.Equals(Email.Trim()) && item.Password.Equals(Password.Trim()))
                {
                    return item;
                }
            }
            return null;

        }

    
    }


}
