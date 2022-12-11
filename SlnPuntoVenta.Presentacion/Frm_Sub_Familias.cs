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
    public partial class Frm_Sub_Familias : Form
    {
        public Frm_Sub_Familias()
        {
            InitializeComponent();
        }
        #region "Mis variables Globales"
        int EstadoGuarda = 0;
        int nCodigo = 0;
        int nCodigoFa = 0;

        #endregion

        #region "Mis Metodos"
        private void FormatoDGVSF()
        {
            dgv_Listado.Columns[0].Width = 100;
            dgv_Listado.Columns[0].HeaderText = "CODIGO SF";
            dgv_Listado.Columns[1].Width = 250;
            dgv_Listado.Columns[1].HeaderText = "SUB FAMILIA";
            dgv_Listado.Columns[2].Width = 250;
            dgv_Listado.Columns[2].HeaderText = "FAMILIA";
            dgv_Listado.Columns[3].Visible = false;

        }
        private void FormatoDGVFA()
        {
            dgv_01.Columns[0].Visible = false;
           
            dgv_01.Columns[1].Width = 350;
            dgv_01.Columns[1].HeaderText = "FAMILIA";
            

        }
        private void ListadoSF(string Ctext)
        {
            try
            {
                dgv_Listado.DataSource = Neg_Sub_Familias.ListarSubFamilias(Ctext);
                this.FormatoDGVSF();
                lblTotalRegistros.Text = "Total de registros: " + dgv_Listado.Rows.Count.ToString();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ListadoFA(string Ctext)
        {
            try
            {
                dgv_01.DataSource = Neg_Sub_Familias.ListarFamilias(Ctext);
                this.FormatoDGVFA();
                           }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }



        private void LimpiarTexto()
        {
            txtDescripcionSF.Text = "";
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
            txtDescripcionSF.ReadOnly = !LEstado;
           // tabControlPrincipal.Enabled = !LEstado;

        }
        private void EstadoBotonesProcesos(bool estado)
        {
            btnCancelar.Visible = estado;
            btnGuardar.Visible = estado;
            btnRetornar.Visible = !estado;
            BotonLupa1.Visible = estado;

        }

        private void SeleccionarItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_Listado.CurrentRow.Cells["CodigoSF"].Value)))
            {
                MessageBox.Show("Seleciona un registro..!", "Aviso del Sistema", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }else
            {
                this.nCodigo = Convert.ToInt32(dgv_Listado.CurrentRow.Cells["CodigoSF"].Value);
                txtDescripcionSF.Text = Convert.ToString(dgv_Listado.CurrentRow.Cells["DescripcionSF"].Value);
                txtDescripcionFA.Text= Convert.ToString(dgv_Listado.CurrentRow.Cells["DescripcionFA"].Value);
                this.nCodigoFa= Convert.ToInt32(dgv_Listado.CurrentRow.Cells["CodigoFA"].Value);
            }

        }
        private void SeleccionarItemFA()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_01.CurrentRow.Cells["CodigoFA"].Value)))
            {
                MessageBox.Show("Seleciona un registro..!", "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                txtDescripcionFA.Text = Convert.ToString(dgv_01.CurrentRow.Cells["DescripcionFA"].Value);
                this.nCodigoFa = Convert.ToInt32(dgv_01.CurrentRow.Cells["CodigoFA"].Value);
            }

        }

        #endregion
        private void Frm_Sub_Familias_Load(object sender, EventArgs e)
        {
            this.ListadoSF("%");
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
            BotonLupa1.Focus();
            

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
            this.ListadoSF("%");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcionSF.Text == string.Empty || txtDescripcionFA.Text== string.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)",
                                    "Aviso del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    txtDescripcionSF.Focus();
                }else
                {
                    string Rpta = "";
                    Ent_Sub_Familias objSubFamilia = new Ent_Sub_Familias();
                    objSubFamilia.CodigoSF = this.nCodigo;
                    objSubFamilia.DescripcionSF = txtDescripcionSF.Text.Trim();
                    objSubFamilia.CodigoFA = this.nCodigoFa;

                    Rpta = Neg_Sub_Familias.GuardarSF(this.EstadoGuarda, objSubFamilia);
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
                        this.nCodigo = 0;
                        this.nCodigoFa = 0;
                        this.ListadoSF("%");

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
                BotonLupa1.Focus();
                


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
                    Rpta = Neg_Sub_Familias.EliminarSF(this.nCodigo);

                    if (Rpta.Equals("Ok"))
                    {
                        this.ListadoSF("%");
                        MessageBox.Show("El registro a sido eliminado",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        this.nCodigo = 0;
                        this.nCodigoFa = 0;


                    }
                    this.LimpiarTexto();

                    tabControlPrincipal.SelectedIndex = 0;

                }
                
                


            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListadoSF(txtBuscar.Text.Trim());


        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (dgv_Listado.Rows.Count > 0)
            {
                //Reportes.Form_Rpta_Sub_Familias = new Reportes.Form_Rpta_Sub_Familias();
                //objReporte.txtParametro1.Text = txtBuscar.Text.Trim();
                //objReporte.ShowDialog();
            }
        }

        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_01_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionarItemFA();
            PnlListado1.Visible = false;
            txtDescripcionSF.Focus();
        }

        private void btnRetornar1_Click(object sender, EventArgs e)
        {
            PnlListado1.Visible = false;
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            this.ListadoFA(txtBuscar1.Text.Trim());
        }

        private void BotonLupa1_Click(object sender, EventArgs e)
        {
            PnlListado1.Visible = true;
            PnlListado1.Location = BotonLupa1.Location;
            txtBuscar1.Focus();

        }
    }
}
