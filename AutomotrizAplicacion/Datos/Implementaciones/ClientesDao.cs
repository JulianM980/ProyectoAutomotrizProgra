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
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@nombre",cliente.Nombre));
            lst.Add(new Parametro("@apellido",cliente.Apellido));
            lst.Add(new Parametro("@doc",cliente.Dni));
            lst.Add(new Parametro("@tel",cliente.NroTel));
            lst.Add(new Parametro("@email",cliente.Email));
            lst.Add(new Parametro("@calle",cliente.Calle));
            lst.Add(new Parametro("@altura",cliente.Altura));
            lst.Add(new Parametro("@codP",cliente.CodPostal));
            lst.Add(new Parametro("@tipoDoc",cliente.TipoDoc));
            lst.Add(new Parametro("@tipo",cliente.TipoCliente.Id));
            lst.Add(new Parametro("@estado",cliente.Estado));
            lst.Add(new Parametro("@idModificar",cliente.Id));

            return HelperDB.ObtenerInstancia().Ejecutar("actualizar_cliente", lst);
        }

        public bool BajaLogica(int idCliente)
        {
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@idCliente",idCliente));
            return HelperDB.ObtenerInstancia().BajaLogica("baja_cliente",lst);
        }

        public bool ComprobarCredenciales(string user, string pass)
        {
            return HelperDB.ObtenerInstancia().Login(user,pass, "comprobar_credenciales");
        }

        public bool Insertar(Cliente cliente)
        {
            List<Parametro> pMaestro = new List<Parametro>();
            pMaestro.Add(new Parametro("@nombre", cliente.Nombre));
            pMaestro.Add(new Parametro("@apellido", cliente.Apellido));
            pMaestro.Add(new Parametro("@doc", cliente.Dni));
            pMaestro.Add(new Parametro("@tel", cliente.NroTel));
            pMaestro.Add(new Parametro("@email", cliente.Email));
            pMaestro.Add(new Parametro("@calle", cliente.Calle));
            pMaestro.Add(new Parametro("@altura", cliente.Altura));
            pMaestro.Add(new Parametro("@codp", cliente.CodPostal));
            pMaestro.Add(new Parametro("@tipoDoc", cliente.TipoDoc));

            

            return HelperDB.ObtenerInstancia().InsertarCliente("INS_DATOS", pMaestro, "@idO", "ins_datos_clientes", cliente);
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
                cliente.TipoCliente.Id = Convert.ToInt16(row["idTipoCliente"]);
                cliente.TipoCliente.Tipo = row["nombre_tipo"].ToString();
                cliente.Estado = Convert.ToBoolean(row["estadoCliente"]);
                cliente.NombreCompleto = row["nombre_completo"].ToString();
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

        public List<Cliente> ObtenerClientePorTipo(int idTipo)
        {
            List<Cliente> clientes = new List<Cliente>();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@tipoCliente", idTipo));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("tipo_cliente", lst);
            foreach (DataRow row in dt.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.Apellido = row["Apellido"].ToString();
                cliente.Nombre = row["Nombre"].ToString();
                cliente.Calle = row["Calle"].ToString();
                cliente.Altura = Convert.ToInt16(row["Altura"]);
                cliente.Email = row["Email"].ToString();
                cliente.NroTel = row["Telefono"].ToString();
                clientes.Add(cliente);
            }
            return clientes;
        }

        public List<TipoCliente> ObtenerTiposClientes()
        {
            List<TipoCliente> tipos = new List<TipoCliente>();
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("Tipos_Clientes");
            if (dt == null) return tipos;
            foreach (DataRow row in dt.Rows)
            {
                TipoCliente tipo = new TipoCliente();
                tipo.Id = Convert.ToInt16(row["idTipoCliente"]);
                tipo.Tipo = row["nombre"].ToString();
               

                tipos.Add(tipo);
            }
            return tipos;
        }

        public List<TipoDoc> ObtenerTiposDoc()
        {
            List<TipoDoc> tipos = new List<TipoDoc>();
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("Tipos_Docs");
            if (dt == null) return tipos;
            foreach (DataRow row in dt.Rows)
            {
                TipoDoc tipo = new TipoDoc();
                tipo.Id = Convert.ToInt16(row["idTipoDoc"]);
                tipo.Tipo = row["nombre"].ToString();


                tipos.Add(tipo);
            }
            return tipos;
        }

        public Cliente ObtenerUno(int id)
        {
            Cliente cliente = new Cliente();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@idCliente",id));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("OB_CLIENTE",lst);
            foreach (DataRow row in dt.Rows)
            {
                cliente.Id = Convert.ToInt16(row["idDatos"]);
                cliente.IdCliente = Convert.ToInt16(row["idCliente"]);
                cliente.TipoCliente.Id = Convert.ToInt16(row["idTipoCliente"]);
                cliente.TipoCliente.Tipo = row["nombre_tipo"].ToString();
                cliente.Estado = Convert.ToBoolean(row["estadoCliente"]);
                cliente.NombreCompleto = row["nombre_completo"].ToString();
                cliente.Nombre = row["nombre"].ToString();
                cliente.Apellido = row["apellido"].ToString();
                cliente.Dni = row["documento"].ToString();
                cliente.NroTel = row["nroTel"].ToString();
                cliente.Email = row["email"].ToString();
                cliente.Calle = row["calle"].ToString();
                cliente.Altura = Convert.ToInt32(row["altura"]);
                cliente.CodPostal = Convert.ToInt32(row["codPostal"]);
                cliente.TipoDoc = Convert.ToInt32(row["idTipoDoc"]);

               
            }
            return cliente;
        }
    }
}
