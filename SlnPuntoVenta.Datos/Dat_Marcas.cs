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
    public class Dat_Marcas
    {
        public DataTable ListarMarcas(string Ctext)
        {
            SqlDataReader resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();
            try
            {
                SQLCon = Conexion.GetInstance().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_LISTADO_MA", SQLCon);
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
        public string GuardarMA(int nOpcion, Ent_Marcas objMarcas)
        {
            string Rpta = "";
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.GetInstance().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_GUARDA_MA", SQLCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nOption", SqlDbType.Int).Value = nOpcion;
                comando.Parameters.Add("@nCodigo", SqlDbType.Int).Value = objMarcas.CodigoMA;
                comando.Parameters.Add("@cDescripcion", SqlDbType.VarChar).Value = objMarcas.DescripcionMA;
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
        public string EliminarMA(int nCodigo)
        {
            string Rpta = "";
            SqlConnection SQLCon = new SqlConnection();
            try
            {
                SQLCon = Conexion.GetInstance().CrearConexion();
                SqlCommand comando = new SqlCommand("USP_ELIMINAR_MA", SQLCon);
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
