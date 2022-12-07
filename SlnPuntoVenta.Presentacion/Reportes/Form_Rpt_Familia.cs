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
    public partial class Form_Rpt_Familia : Form
    {
        public Form_Rpt_Familia()
        {
            InitializeComponent();
        }

        private void Form_Rpt_Familia_Load(object sender, EventArgs e)
        {
            this.USP_LISTADO_FATableAdapter.Fill(this.DataSet_DatosMaestros.USP_LISTADO_FA, CTexto: txtParametro1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
