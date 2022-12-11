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
    public class Neg_Sub_Familias
    {
        public static DataTable ListarSubFamilias(string Ctext)
        {
            Dat_Sub_Familias datos = new Dat_Sub_Familias();
            return datos.ListarSubFamilias(Ctext);
        }

        public static string GuardarSF(int nOpcion, Ent_Sub_Familias objSubFamilia)
        {
            Dat_Sub_Familias objGuardarSF = new Dat_Sub_Familias();
            return objGuardarSF.GuardarSF(nOpcion, objSubFamilia);
        }

        public static string EliminarSF(int nCodigo)
        {
            Dat_Sub_Familias objEliminarSF = new Dat_Sub_Familias();
            return objEliminarSF.EliminarSF(nCodigo);
        }
        public static DataTable ListarFamilias(string Ctext)
        {
            Dat_Sub_Familias datos = new Dat_Sub_Familias();
            return datos.ListarFamilias(Ctext);
        }
    }
}
