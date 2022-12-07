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
    public partial class Form_Rpt_UnidadesMedida : Form
    {
        public Form_Rpt_UnidadesMedida()
        {
            InitializeComponent();
        }

        private void Form_Rpt_UnidadesMedida_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet_DatosMaestros.USP_LISTADO_UM' Puede moverla o quitarla según sea necesario.
            this.USP_LISTADO_UMTableAdapter.Fill(this.DataSet_DatosMaestros.USP_LISTADO_UM,txtParametro1.Text.Trim());

            this.reportViewer1.RefreshReport();
        }
    }
}
