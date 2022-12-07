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
    public class Neg_UnidadesMedida
    {
        public static DataTable ListarUnidadesMedida(string Ctext)
        {
            Dat_UnidadesMedida datos = new Dat_UnidadesMedida();
            return datos.ListarUnidadesMedida(Ctext);
        }
        public static string GuardarUM(int nOpcion, Ent_UnidadesMedida objUnidadMedidas)
        {
            Dat_UnidadesMedida objGuardarUM = new Dat_UnidadesMedida();
            return objGuardarUM.GuardarUM(nOpcion, objUnidadMedidas);
        }
        public static string EliminarUM(int nCodigo)
        {
            Dat_UnidadesMedida objEliminarUM = new Dat_UnidadesMedida();
            return objEliminarUM.EliminarUM(nCodigo);
        }
    }
}
