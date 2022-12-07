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
    public partial class Form_Rpt_Marcas : Form
    {
        public Form_Rpt_Marcas()
        {
            InitializeComponent();
        }

        private void Form_Rpt_Marcas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet_DatosMaestros.USP_LISTADO_MA' Puede moverla o quitarla según sea necesario.
            this.USP_LISTADO_MATableAdapter.Fill(this.DataSet_DatosMaestros.USP_LISTADO_MA,CTexto:txtParametro1.Text.Trim());

            this.reportViewer1.RefreshReport();
        }
    }
}
