using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlnPuntoVenta.Entity;
using SlnPuntoVenta.Negocio;

namespace SlnPuntoVenta.Presentacion
{
    public partial class Frm_Familias : Form
    {
        public Frm_Familias()
        {
            InitializeComponent();
        }
        #region "Mis variables Globales"
        int EstadoGuarda = 0;
        int nCodigo = 0;

        #endregion

        #region "Mis Metodos"
        private void FormatoDGVPV()
        {
            dgv_Listado.Columns[0].Width = 100;
            dgv_Listado.Columns[0].HeaderText = "CODIGO FA";
            dgv_Listado.Columns[1].Width = 350;
            dgv_Listado.Columns[1].HeaderText = "FAMILIA";
        }
        private void ListadoFA(string Ctext)
        {
            try
            {
                dgv_Listado.DataSource = Neg_Familias.ListarFamilias(Ctext);
                this.FormatoDGVPV();
                lblTotalRegistros.Text = "Total de registros: " + dgv_Listado.Rows.Count.ToString();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void LimpiarTexto()
        {
            txtDescripcionFA.Text = "";

        }

        private void EstadoBotonesPrincipales(bool LEstado)
        {
            btnNuevo.Enabled = LEstado;
            btnActualizar.Enabled = LEstado;
            btnEliminar.Enabled = LEstado;
            btnReporte.Enabled = LEstado;
            btnSalir.Enabled = LEstado;

        }
        private void Estado_Texto(bool LEstado)
        {
            txtDescripcionFA.ReadOnly = !LEstado;
           // tabControlPrincipal.Enabled = !LEstado;

        }
        private void EstadoBotonesProcesos(bool estado)
        {
            btnCancelar.Visible = estado;
            btnGuardar.Visible = estado;
            btnRetornar.Visible = !estado;

        }

        private void SeleccionarItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_Listado.CurrentRow.Cells["CodigoFA"].Value)))
            {
                MessageBox.Show("Seleciona un registro..!", "Aviso del Sistema", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }else
            {
                this.nCodigo = Convert.ToInt32(dgv_Listado.CurrentRow.Cells["CodigoFA"].Value);
                txtDescripcionFA.Text = Convert.ToString(dgv_Listado.CurrentRow.Cells["DescripcionFA"].Value);

            }

        }

        #endregion
        private void Frm_Familias_Load(object sender, EventArgs e)
        {
            this.ListadoFA("%");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.EstadoBotonesPrincipales(false);
            this.EstadoGuarda = 1;  // Nuevo Registro
            this.EstadoBotonesProcesos(true);
            this.LimpiarTexto();
            this.Estado_Texto(true);
            tabControlPrincipal.SelectedIndex = 1;
            
            txtDescripcionFA.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarTexto();
            this.Estado_Texto(false);
            this.EstadoBotonesPrincipales(true);
            this.EstadoBotonesProcesos(false);
            tabControlPrincipal.SelectedIndex = 0;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 0;
            this.ListadoFA("%");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcionFA.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)",
                                    "Aviso del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }else
                {
                    string Rpta = "";
                    Ent_Familias objFamilia = new Ent_Familias();
                    objFamilia.CodigoFA = this.nCodigo;
                    objFamilia.DescripcionFA = txtDescripcionFA.Text.Trim();
                    Rpta = Neg_Familias.GuardarFA(this.EstadoGuarda, objFamilia);
                    if (Rpta.Equals("Ok"))
                    {
                        MessageBox.Show("Los Datos Fueron Guardados Correctamente",
                                         "Aviso del Sistema",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Exclamation);
                        this.LimpiarTexto();
                        this.Estado_Texto(false);
                        this.EstadoBotonesPrincipales(true);
                        this.EstadoBotonesProcesos(false);
                        this.EstadoGuarda = 0;
                        this.ListadoFA("%");
                        tabControlPrincipal.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                      


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message +  ex.StackTrace);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgv_Listado.Rows.Count>0)
            {
                this.EstadoGuarda = 0; // Actualizar registro
                this.EstadoBotonesPrincipales(false);
                this.EstadoBotonesProcesos(true);
                this.Estado_Texto(true);
                this.SeleccionarItem();
                tabControlPrincipal.SelectedIndex = 1;
                txtDescripcionFA.Focus();


            }
        }

        private void dgv_Listado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgv_Listado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.EstadoGuarda==0) 
            { 
                this.SeleccionarItem();
                this.EstadoBotonesProcesos(false);
                tabControlPrincipal.SelectedIndex = 1;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            if (dgv_Listado.Rows.Count > 0)
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro de eliminar el registro seleccionado", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion==DialogResult.Yes)
                {
                    string Rpta = "";
                    this.SeleccionarItem();
                    Rpta = Neg_Familias.EliminarFA(this.nCodigo);

                    if (Rpta.Equals("Ok"))
                    {
                        this.ListadoFA("%");
                        MessageBox.Show("El registro a sido eliminado",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);


                    }
                    this.LimpiarTexto();

                    tabControlPrincipal.SelectedIndex = 0;

                }
                
                


            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListadoFA(txtBuscar.Text.Trim());


        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (dgv_Listado.Rows.Count > 0)
            {
                Reportes.Form_Rpt_Familia objReporte = new Reportes.Form_Rpt_Familia();
                objReporte.txtParametro1.Text = txtBuscar.Text.Trim();
                objReporte.ShowDialog();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
