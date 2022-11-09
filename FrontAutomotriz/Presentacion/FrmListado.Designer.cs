using System.Drawing.Printing;

namespace Reportes
{
    partial class FrmListado
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
            this.dTListadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSListado = new FrontAutomotriz.Presentacion.Reporte.DSListado();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSListadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTListadoTableAdapter = new FrontAutomotriz.Presentacion.Reporte.DSListadoTableAdapters.DTListadoTableAdapter();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dTListadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSListadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dTListadoBindingSource
            // 
            this.dTListadoBindingSource.DataMember = "DTListado";
            this.dTListadoBindingSource.DataSource = this.dSListado;
            // 
            // dSListado
            // 
            this.dSListado.DataSetName = "DSListado";
            this.dSListado.Namespace = "http://tempuri.org/DSListado.xsd";
            this.dSListado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DSFacturas";
            reportDataSource1.Value = this.dTListadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FrontAutomotriz.Presentacion.Reporte.ListadoFacturas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(180, 60);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(775, 600);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSListadoBindingSource
            // 
            this.dSListadoBindingSource.DataSource = this.dSListado;
            this.dSListadoBindingSource.Position = 0;
            // 
            // dTListadoTableAdapter
            // 
            this.dTListadoTableAdapter.ClearBeforeFill = true;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 55;
            this.iconPictureBox2.Location = new System.Drawing.Point(957, 2);
            this.iconPictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(56, 55);
            this.iconPictureBox2.TabIndex = 13;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.iconPictureBox2_Click);
            // 
            // FrmListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 532);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmListado";
            this.Text = "FrmReporte";
            this.Load += new System.EventHandler(this.FrmListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dTListadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSListadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dSListadoBindingSource;
        private FrontAutomotriz.Presentacion.Reporte.DSListado dSListado;
        private System.Windows.Forms.BindingSource dTListadoBindingSource;
        private FrontAutomotriz.Presentacion.Reporte.DSListadoTableAdapters.DTListadoTableAdapter dTListadoTableAdapter;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
    }
}