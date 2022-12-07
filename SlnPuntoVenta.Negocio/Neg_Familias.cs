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
    public class Neg_Familias
    {
        public static DataTable ListarFamilias(string Ctext)
        {
            Dat_Familias datos = new Dat_Familias();
            return datos.ListarFamilias(Ctext);
        }
        public static string GuardarFA(int nOpcion, Ent_Familias objFamilia)
        {
            Dat_Familias objGuardarFA = new Dat_Familias();
            return objGuardarFA.GuardarFA(nOpcion, objFamilia);
        }
        public static string EliminarFA(int nCodigo)
        {
            Dat_Familias objEliminarFA = new Dat_Familias();
            return objEliminarFA.EliminarFA(nCodigo);
        }
    }
}
