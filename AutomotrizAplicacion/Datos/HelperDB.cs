using AutomotrizAplicacion.Servicios;
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
            cnn = new SqlConnection();
        }
        public static HelperDB ObtenerInstancia() {
            if (instancia == null) { 
                instancia = new HelperDB();
            }
            return instancia;
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
        
    }
}
