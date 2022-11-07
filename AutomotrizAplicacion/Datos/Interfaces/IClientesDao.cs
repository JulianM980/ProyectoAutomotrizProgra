using AutomotrizAplicacion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Datos.Interfaces
{
    public  interface IClientesDao
    {
        List<Cliente> Obtener();
        Cliente ObtenerUno(int id);
        List<TipoCliente> ObtenerTiposClientes();
        List<TipoDoc> ObtenerTiposDoc();

        bool Insertar(Cliente cliente);
        bool Actualizar(Cliente cliente);
        bool BajaLogica(int idCliente);
        bool ComprobarCredenciales(string user,string pass);
    }
}
