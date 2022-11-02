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
using System.Windows.Forms;

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
                MessageBox.Show("Error en base de datos");
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

                MessageBox.Show("Error en base de datos");
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
                cmdMaestro.ExecuteNonQuery();
                int id = Convert.ToInt16(param.Value);
                foreach (DetalleDocumento dd in f.DetallesFactura)
                {
                    
                    SqlCommand cmdDetalles = new SqlCommand(spDetalle, cnn, t);
                    cmdDetalles.CommandType = CommandType.StoredProcedure;
                    cmdDetalles.Parameters.AddWithValue("@nroFactura", id);
                    cmdDetalles.Parameters.AddWithValue("@precio",dd.PrecioUnitario);
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
        public int Login(string usuario,string pass)
        {
            int aux;
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "Sp_Login";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@pass", pass);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                     aux=dr.GetInt32(0);
                    return aux;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            finally
            {
                cnn.Close();
            }

            return aux=-1;
        }

    }
}
