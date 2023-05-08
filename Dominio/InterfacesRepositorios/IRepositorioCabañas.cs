using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;


namespace Dominio.InterfacesRespositorios
{
    public interface IRepositorioCabañas : IRepositorio<Cabaña>
    {
        //Dejo esto de guia aca va el metodo que tenga el repo
        //IEnumerable<Cabaña> CabañasConIncial(char inicial);
        // IEnumerable<Cabaña> CabañaPorTexto(string txt);

        //IEnumerable<Cabaña> CabañasPorTipo(Tipo tipo);

        IEnumerable<Cabaña> CabañasPorCantMaxPersonas(int cantMax);
        //IEnumerable<Cabaña> CabañasHabilitadas();



    }
}
