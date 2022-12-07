using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SlnPuntoVenta.Entity;
using System.Data;


namespace SlnPuntoVenta.Datos
{
    public class Dat_UnidadesMedida
    {
        public DataTable ListarUnidadesMedida(string Ctext)
        {
            SqlDataReader resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();
            try
            {
                SQLCon = Conexion.GetInstance().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_LISTADO_UM", SQLCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@CTexto", SqlDbType.VarChar).Value = Ctext;
                SQLCon.Open();
                resultado = comando.ExecuteReader();
                Tabla.Load(resultado);
                return Tabla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open)
                {
                    SQLCon.Close();
                }
            }



        }
        public string GuardarUM(int nOpcion, Ent_UnidadesMedida objUnidadesMedidas)
        {
            string Rpta = "";
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.GetInstance().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_GUARDA_UM", SQLCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nOption", SqlDbType.Int).Value = nOpcion;
                comando.Parameters.Add("@nCodigo", SqlDbType.Int).Value = objUnidadesMedidas.CodigoUM;
                comando.Parameters.Add("@cDescripcion", SqlDbType.VarChar).Value = objUnidadesMedidas.DescripcionUM;
                SQLCon.Open();
                Rpta = comando.ExecuteNonQuery() >= 1 ? "Ok" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open)
                {
                    SQLCon.Close();
                }
            }
            return Rpta;
        }
        public string EliminarUM(int nCodigo)
        {
            string Rpta = "";
            SqlConnection SQLCon = new SqlConnection();
            try
            {
                SQLCon = Conexion.GetInstance().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_ELIMINAR_UM", SQLCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nCodigo", SqlDbType.Int).Value = nCodigo;
                SQLCon.Open();
                Rpta = comando.ExecuteNonQuery() >= 1 ? "Ok" : "No se Pudo eliminar el registro";

            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open)
                {
                    SQLCon.Close();
                }
            }
            return Rpta;

        }
    }
}
