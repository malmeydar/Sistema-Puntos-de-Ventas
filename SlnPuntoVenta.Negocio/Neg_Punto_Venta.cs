using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SlnPuntoVenta.Entity;
using SlnPuntoVenta.Datos;

namespace SlnPuntoVenta.Negocio
{
    public class Neg_Punto_Venta
    {
        public static DataTable ListarPuntoVenta(string Ctext)
        {
            Dat_Punto_Venta datos = new Dat_Punto_Venta();
            return datos.ListarPuntoVenta(Ctext);
        }
        public static string GuardarPV(int nOpcion, Ent_Punto_Venta objPuntoVenta)
        {
            Dat_Punto_Venta objGuardarPV = new Dat_Punto_Venta();
            return objGuardarPV.GuardarPV(nOpcion, objPuntoVenta);
        }
        public static string EliminarPV(int nCodigo)
        {
            Dat_Punto_Venta objEliminarPV = new Dat_Punto_Venta();
            return objEliminarPV.EliminarPV(nCodigo);
        }
    }
}
