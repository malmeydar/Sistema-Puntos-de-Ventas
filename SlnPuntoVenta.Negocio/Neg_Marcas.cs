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
    public class Neg_Marcas
    {
        public static DataTable ListarMarcas(string Ctext)
        {
            Dat_Marcas datos = new Dat_Marcas();
            return datos.ListarMarcas(Ctext);
        }
        public static string GuardarMA(int nOpcion, Ent_Marcas objMarcas)
        {
            Dat_Marcas objGuardarMA = new Dat_Marcas();
            return objGuardarMA.GuardarMA(nOpcion, objMarcas);
        }
        public static string EliminarMA(int nCodigo)
        {
            Dat_Marcas objEliminarMA = new Dat_Marcas();
            return objEliminarMA.EliminarMA(nCodigo);
        }
    }
}
