
namespace SlnPuntoVenta.Presentacion.Reportes
{
    partial class Form_Rpt_Familia
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet_DatosMaestros = new SlnPuntoVenta.Presentacion.Reportes.DataSet_DatosMaestros();
            this.USP_LISTADO_FABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_LISTADO_FATableAdapter = new SlnPuntoVenta.Presentacion.Reportes.DataSet_DatosMaestrosTableAdapters.USP_LISTADO_FATableAdapter();
            this.txtParametro1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_DatosMaestros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_LISTADO_FABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.USP_LISTADO_FABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SlnPuntoVenta.Presentacion.Reportes.Rpt_Familias.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet_DatosMaestros
            // 
            this.DataSet_DatosMaestros.DataSetName = "DataSet_DatosMaestros";
            this.DataSet_DatosMaestros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_LISTADO_FABindingSource
            // 
            this.USP_LISTADO_FABindingSource.DataMember = "USP_LISTADO_FA";
            this.USP_LISTADO_FABindingSource.DataSource = this.DataSet_DatosMaestros;
            // 
            // USP_LISTADO_FATableAdapter
            // 
            this.USP_LISTADO_FATableAdapter.ClearBeforeFill = true;
            // 
            // txtParametro1
            // 
            this.txtParametro1.Location = new System.Drawing.Point(12, 32);
            this.txtParametro1.Name = "txtParametro1";
            this.txtParametro1.Size = new System.Drawing.Size(100, 20);
            this.txtParametro1.TabIndex = 2;
            this.txtParametro1.Visible = false;
            // 
            // Form_Rpt_Familia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtParametro1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form_Rpt_Familia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Rpt_Familia";
            this.Load += new System.EventHandler(this.Form_Rpt_Familia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_DatosMaestros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_LISTADO_FABindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_LISTADO_FABindingSource;
        private DataSet_DatosMaestros DataSet_DatosMaestros;
        private DataSet_DatosMaestrosTableAdapters.USP_LISTADO_FATableAdapter USP_LISTADO_FATableAdapter;
        internal System.Windows.Forms.TextBox txtParametro1;
    }
}