using Altas;
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
       
        #endregion
        #region EVENTOS
        private void FrmIndex_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.lblTituloPrincipal.Parent = pictureBox1;
            this.iconPictureBox1.Parent = pictureBox1;
            this.iconPictureBox2.Parent = pictureBox1;
            this.lblDescripcion.Parent = pictureBox1;
        }
        private void Consulta1_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(new FrmConsultaFacturas());
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
           // AbrirFormulario(new FrmConsulta4());

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
    }
}
