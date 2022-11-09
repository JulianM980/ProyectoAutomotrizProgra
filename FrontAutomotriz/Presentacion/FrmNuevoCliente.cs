using AutomotrizAplicacion.Dominio;
using FrontAutomotriz.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altas.Forms
{
    public partial class FrmNuevoCliente : Form
    {
        private Cliente oCliente;
        public FrmNuevoCliente()
        {
            InitializeComponent();
            oCliente = new Cliente();
        }

        private async void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            await CargarTiposClientes();
            await CargarTiposDocumentos();
        }
        #region METODOS PRIVADOS
        private async Task CargarTiposClientes() {
            string url = "http://localhost:5197/tiposClientes";
            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<TipoCliente>>(result);

            cbTipoCliente.DataSource = lst;
            cbTipoCliente.DisplayMember = "Tipo";
            cbTipoCliente.ValueMember = "Id";
        }
        private async Task CargarTiposDocumentos() {
            string url = "http://localhost:5197/tiposDocs";
            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<TipoCliente>>(result);

            cbTipoDoc.DataSource = lst;
            cbTipoDoc.DisplayMember = "Tipo";
            cbTipoDoc.ValueMember = "Id";
        }
        
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            oCliente.Nombre = txtNombre.Text;
            oCliente.Apellido = txtApellido.Text;
            oCliente.NombreCompleto = txtNombre.Text + txtApellido.Text;
            oCliente.Dni = txtNroDoc.Text;
            oCliente.TipoCliente.Id = Convert.ToInt16(cbTipoCliente.SelectedValue);
            oCliente.TipoDoc = Convert.ToInt16(cbTipoDoc.SelectedValue);
            oCliente.Calle = txtCalle.Text;
            oCliente.Altura = Convert.ToInt32(txtAltura.Text);
            oCliente.CodPostal = Convert.ToInt32(txtCodigoPostal.Text);
            oCliente.NroTel = txtTelefono.Text;
            oCliente.Email = txtEmail.Text;
            oCliente.Estado = true;

            bool saveOk = await GuardarCliente(oCliente);

            if (saveOk)
            {
                MessageBox.Show("Cliente registrado con exito");
                this.Dispose();
            }
            else {
                MessageBox.Show("Error al cargar cliente. Intente mas tarde");
            }
        }
        private async Task<bool> GuardarCliente(Cliente oCliente)
        {
            string bodyContent = JsonConvert.SerializeObject(oCliente);

            string url = "http://localhost:5197/clientes";

            //StringContent le pasamos el contenido,el tipo de codificacion y el tipo de dato
            var result = await ClientSingleton.ObtenerCliente().PostAsync(url, bodyContent);
            return result.Equals("true");

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Minimized;
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("¿Desea cerrar pestaña?", "Saliendo formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes) this.Dispose();
        }
    }
}
