using AutomotrizAplicacion.Datos.Interfaces;
using AutomotrizAplicacion.Dominio;
using RecetasSLN.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Datos.Implementaciones
{
    public class ClientesDao : IClientesDao
    {
        public bool Actualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(int idCliente)
        {
            throw new NotImplementedException();
        }

        public bool ComprobarCredenciales(string user, string pass)
        {
            return HelperDB.ObtenerInstancia().Login(user,pass, "comprobar_credenciales");
        }

        public bool Insertar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Obtener()
        {
            List<Cliente> clientes = new List<Cliente>();
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("OB_CLIENTES");
            if (dt == null) return clientes;
            foreach (DataRow row in dt.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt16(row["idCliente"]);
                cliente.TipoCliente = Convert.ToInt16(row["idTipoCliente"]);
                cliente.Estado = Convert.ToBoolean(row["estadoCliente"]);
                cliente.Apellido = row["apellido"].ToString();
                cliente.Nombre = row["nombre"].ToString();
                cliente.Dni = row["documento"].ToString();
                cliente.NroTel = row["nroTel"].ToString();
                cliente.Email = row["email"].ToString();
                cliente.Calle = row["calle"].ToString();
                cliente.Altura = Convert.ToInt32(row["altura"]);
                cliente.CodPostal = Convert.ToInt32(row["codPostal"]);
                cliente.TipoDoc = Convert.ToInt32(row["idTipoDoc"]);

                clientes.Add(cliente);
            }
            return clientes;
        }
    }
}
