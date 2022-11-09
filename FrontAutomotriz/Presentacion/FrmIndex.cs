using Altas;
using Altas.Consultar;
using FrontAutomotriz.Presentacion;
using Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ProyectoAutomotriz
{
    public partial class FrmIndex : Form
    {
        private Form formularioActivo = null;
        public FrmIndex()
        {
            InitializeComponent();
        }
        #region METODOS PRIVADOS
        
        private void AbrirFormulario(Form nuevoFormulario) {
            if (formularioActivo != null) formularioActivo.Close();
            formularioActivo = nuevoFormulario;
            nuevoFormulario.TopLevel = false;
            nuevoFormulario.FormBorderStyle = FormBorderStyle.None;
            nuevoFormulario.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(nuevoFormulario);
            panelContenedor.Tag = nuevoFormulario;
            nuevoFormulario.BringToFront();
            nuevoFormulario.Show();
        }
        private void Paneles() {
            pTransacciones.Visible = false;
            pReportes.Visible = false;
        }
        private void EsconderSubMenu() { 
            if(pTransacciones.Visible == true) pTransacciones.Visible = false;
            if(pReportes.Visible == true) pReportes.Visible = false;
        }
        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                EsconderSubMenu();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;
        }
        #endregion
        #region EVENTOS
        private void FrmIndex_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.lblTituloPrincipal.Parent = pictureBox1;
            this.iconPictureBox1.Parent = pictureBox1;
            this.iconPictureBox2.Parent = pictureBox1;

            Paneles();
        }
        private void Consulta1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmConsultar());
        }
        private void Consulta2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAltaFactura());

        }
        private void Consulta3_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(new FrmConsulta3());

        }

        private void Consulta4_Click(object sender, EventArgs e)
        {
           AbrirFormulario(new Reportes.FrmListado());

        }

       
       
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("¿Desea salir de la aplicacion?", "Saliendo formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes) this.Dispose();
        }

        
        private void iconPictureBox1_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Minimized;

        }

      

        private void btnConsultarFacturas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmConsultar());
            EsconderSubMenu();
        }

        private void btnIngresarFacturas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAltaFactura());
            EsconderSubMenu();

        }

        private void btnSoporte_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmConsultaCliente());
        }

        private void btnTransDesplegable_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pTransacciones);
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmListado());
            EsconderSubMenu();

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmReporte());
            EsconderSubMenu();

        }

        private void btnRepDesplegable_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pReportes);

        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmLegajos()); 
        }
    }
}
