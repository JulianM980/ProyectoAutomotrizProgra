using AutomotrizAplicacion.Datos;
using AutomotrizAplicacion.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos
{
    internal class HelperDB
    {
        private static HelperDB instancia;
        private SqlConnection cnn;
        private HelperDB()
        {
            cnn = new SqlConnection(@"Data Source=DESKTOP-0A8E6DU\SQLEXPRESS;Initial Catalog=GRUPO_10;Integrated Security=True");
        }
        public static HelperDB ObtenerInstancia() {
            if (instancia == null) { 
                instancia = new HelperDB();
            }
            return instancia;
        }
        public DataTable ConsultarSp(string sp)
        {
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {

                dt = null;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return dt;
        }
        public DataTable ConsultarSp(string sp,List<Parametro> param) {
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (Parametro p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }
                }
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {

                dt = null;
            }
            finally {
                if (cnn != null && cnn.State == ConnectionState.Open) {
                    cnn.Close();
                }
            }
            return dt;
        }
        public int ConsultaEscalarSp(string sp, string parametroSalida) {
            int resultado = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter(parametroSalida, SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                resultado = Convert.ToInt32(param.Value);
            }
            catch (Exception)
            {
                return resultado;
            }
            finally {
                if (cnn != null && cnn.State == ConnectionState.Open) {
                    cnn.Close();
                }
            }
            return resultado;
        }
        public int EjecutarSp(string sp, List<Parametro> param)
        {
            int resultado = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (Parametro p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }
                }
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                //MessageBox.Show("Error en base de datos");
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return resultado;
        }
        public bool Ejecutar(string sp, List<Parametro> param)
        {
            bool resultado = true;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (Parametro p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }
                }
                int aux = cmd.ExecuteNonQuery();
                if (aux < 0) resultado = false;
            }
            catch (Exception)
            {

                //MessageBox.Show("Error en base de datos");
                resultado = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return resultado;
        }
        public bool InsertarFactura(string spMaestro,List<Parametro> pMaestro,string pOutput,string spDetalle,Factura f) {
            bool resultado = true;
            SqlTransaction t = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmdMaestro = new SqlCommand(spMaestro, cnn, t);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                foreach (Parametro p in pMaestro)
                {
                    cmdMaestro.Parameters.AddWithValue(p.Nombre, p.Valor);
                }
                SqlParameter param = new SqlParameter(pOutput, SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(param);
                cmdMaestro.ExecuteNonQuery();
                int id = Convert.ToInt16(param.Value);
                foreach (DetalleDocumento dd in f.DetallesFactura)
                {
                    
                    SqlCommand cmdDetalles = new SqlCommand(spDetalle, cnn, t);
                    cmdDetalles.CommandType = CommandType.StoredProcedure;
                    cmdDetalles.Parameters.AddWithValue("@nroFactura", id);
                    cmdDetalles.Parameters.AddWithValue("@precio",dd.Producto.Precio);
                    cmdDetalles.Parameters.AddWithValue("@cant",dd.Cantidad);
                    cmdDetalles.Parameters.AddWithValue("@producto",dd.Producto.IdProducto);
                    
                    cmdDetalles.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception)
            {

                if (t != null) resultado = false;
                t.Rollback();
            }
            finally {
                if (cnn != null && cnn.State == ConnectionState.Open) {
                    cnn.Close();
                }
            }

            return resultado;
        
        }
        public bool InsertarCliente(string spMaestro, List<Parametro> pMaestro, string pOutput, string spDetalle, Cliente cliente)
        {
            bool resultado = true;
            SqlTransaction t = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmdMaestro = new SqlCommand(spMaestro, cnn, t);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                foreach (Parametro p in pMaestro)
                {
                    if(p.Valor == null) cmdMaestro.Parameters.AddWithValue(p.Nombre, DBNull.Value);
                    else cmdMaestro.Parameters.AddWithValue(p.Nombre, p.Valor);
                }
                SqlParameter param = new SqlParameter(pOutput, SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(param);
                cmdMaestro.ExecuteNonQuery();
                int id = Convert.ToInt16(param.Value);

                SqlCommand cmdDetalles = new SqlCommand(spDetalle, cnn, t);
                cmdDetalles.CommandType = CommandType.StoredProcedure;
                cmdDetalles.Parameters.AddWithValue("@idDatos", id);
                cmdDetalles.Parameters.AddWithValue("@tipo", cliente.TipoCliente.Id);

                cmdDetalles.ExecuteNonQuery();
                
                t.Commit();
            }
            catch (Exception)
            {

                if (t != null) resultado = false;
                t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return resultado;

        }
        public bool BajaLogica(string sp, List<Parametro> lst) {
            bool aux;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp,cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (Parametro p in lst) {
                    cmd.Parameters.AddWithValue(p.Nombre,p.Valor);
                }
                int n = cmd.ExecuteNonQuery();
                if(n == 1) aux = true;
                else aux = false;
            }
            catch (Exception e)
            {
                aux = false;
            }
            finally
            {
                cnn.Close();
            }

            return aux;
        }
        public bool Login(string usuario,string pass,string sp)
        {
            bool aux = true;
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp,cnn);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", usuario);
                cmd.Parameters.AddWithValue("@pass", pass);
                SqlParameter param = new SqlParameter("@cant",SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int cantidad = Convert.ToInt32(param.Value);
                if (cantidad != 1) aux = false;
                //if (dr.Read() && dr.HasRows) { 

                //    if (dr.GetInt32(0) != 1) aux = false;
                //}
                //dr.Close();

            }
            catch(Exception e)
            {
                aux = false;
            }
            finally
            {
                cnn.Close();
            }

            return aux;
        }

    }
}
