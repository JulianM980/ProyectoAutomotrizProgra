using AutomotrizAplicacion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Fachada
{
    public interface IDataClientes
    {
        List<Cliente> ObtenerClientes();
        Cliente ObtenerUno(int id);

        List<TipoCliente> ObtenerTiposClientes();
        List<TipoDoc> ObtenerTiposDoc();

        bool InsertarCliente(Cliente cliente);
        bool ActualizarCliente(Cliente cliente);
        bool BajaLogicaCliente(int idCliente);
        bool ComprobarCredenciales(string user, string pass);

    }
}
