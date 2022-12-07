using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlnPuntoVenta.Presentacion.Reportes
{
    public partial class Frm_Rpt_Punto_Venta : Form
    {
        public Frm_Rpt_Punto_Venta()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Punto_Venta_Load(object sender, EventArgs e)
        {
            this.USP_LISTADO_PVTableAdapter.Fill(this.DataSet_DatosMaestros.USP_LISTADO_PV,CTexto:txtParametro1.Text);
            this.reportViewer1.RefreshReport();
           
        }

        private void txtParametro1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
