using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SlnPuntoVenta.Datos
{
   public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;


        private Conexion()
        {
            this.Base = "BDSistemaPuntoVentas";
            this.Servidor = "DESKTOP-M0KHQK9";
            this.Usuario = "UsuarioSistemasVentas";
            this.Clave = "mdp123$$";
        }
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor +
                                        "; Database=" + this.Base +
                                        "; User id=" + this.Usuario +
                                        "; Password=" + this.Clave;

            }
            catch (Exception ex)
            {

                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion GetInstance()
        {
            if (Con == null)
            {
                Con = new Conexion();

            }
            return Con;
        }


    }
}
