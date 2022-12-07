
namespace SlnPuntoVenta.Presentacion.Reportes
{
    partial class Frm_Rpt_Punto_Venta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.USP_LISTADO_PVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet_DatosMaestros = new SlnPuntoVenta.Presentacion.Reportes.DataSet_DatosMaestros();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_LISTADO_PVTableAdapter = new SlnPuntoVenta.Presentacion.Reportes.DataSet_DatosMaestrosTableAdapters.USP_LISTADO_PVTableAdapter();
            this.txtParametro1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.USP_LISTADO_PVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_DatosMaestros)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_LISTADO_PVBindingSource
            // 
            this.USP_LISTADO_PVBindingSource.DataMember = "USP_LISTADO_PV";
            this.USP_LISTADO_PVBindingSource.DataSource = this.DataSet_DatosMaestros;
            // 
            // DataSet_DatosMaestros
            // 
            this.DataSet_DatosMaestros.DataSetName = "DataSet_DatosMaestros";
            this.DataSet_DatosMaestros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_LISTADO_PVBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SlnPuntoVenta.Presentacion.Reportes.Rpt_PuntoVenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // USP_LISTADO_PVTableAdapter
            // 
            this.USP_LISTADO_PVTableAdapter.ClearBeforeFill = true;
            // 
            // txtParametro1
            // 
            this.txtParametro1.Location = new System.Drawing.Point(13, 41);
            this.txtParametro1.Name = "txtParametro1";
            this.txtParametro1.Size = new System.Drawing.Size(100, 20);
            this.txtParametro1.TabIndex = 1;
            this.txtParametro1.Visible = false;
            this.txtParametro1.TextChanged += new System.EventHandler(this.txtParametro1_TextChanged);
            // 
            // Frm_Rpt_Punto_Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtParametro1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Punto_Venta";
            this.Text = "Frm_Rpt_Punto_Venta";
            this.Load += new System.EventHandler(this.Frm_Rpt_Punto_Venta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_LISTADO_PVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_DatosMaestros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_LISTADO_PVBindingSource;
        private DataSet_DatosMaestros DataSet_DatosMaestros;
        private DataSet_DatosMaestrosTableAdapters.USP_LISTADO_PVTableAdapter USP_LISTADO_PVTableAdapter;
        internal System.Windows.Forms.TextBox txtParametro1;
    }
}