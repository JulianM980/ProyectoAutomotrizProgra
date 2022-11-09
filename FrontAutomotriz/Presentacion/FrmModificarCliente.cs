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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAutomotriz.Presentacion
{
    public partial class FrmModificarCliente : Form
    {
        private Cliente oCliente;
        public FrmModificarCliente(int idCliente,int idDatos)
        {
            InitializeComponent();
            oCliente = new Cliente();
            oCliente.IdCliente = idCliente;
            oCliente.Id = idDatos;
        }
        private async void FrmModificarCliente_Load(object sender, EventArgs e)
        {
            await CargarTiposClientes();
            await CargarTiposDocumentos();
            await CargarCliente(oCliente.IdCliente);
            iconPictureBox2.Parent = panelSuperior;
            lblTitulo.Parent = panelSuperior;
        }
        private async Task CargarTiposClientes()
        {
            string url = "http://localhost:5197/tiposClientes";
            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<TipoCliente>>(result);

            cbTipoCliente.DataSource = lst;
            cbTipoCliente.DisplayMember = "Tipo";
            cbTipoCliente.ValueMember = "Id";
        }
        private async Task CargarTiposDocumentos()
        {
            string url = "http://localhost:5197/tiposDocs";
            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<TipoCliente>>(result);

            cbTipoDoc.DataSource = lst;
            cbTipoDoc.DisplayMember = "Tipo";
            cbTipoDoc.ValueMember = "Id";
        }
        private async Task CargarCliente(int id)
        {
            string url = $"http://localhost:5197/cliente/{id}";
            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);
            var cliente = JsonConvert.DeserializeObject<Cliente>(result);

            txtApellido.Text = cliente.Apellido;
            txtNombre.Text = cliente.Nombre;
            txtNroDoc.Text = cliente.Dni;
            cbTipoCliente.SelectedValue = cliente.TipoCliente.Id;
            cbTipoDoc.SelectedValue = cliente.TipoDoc;
            txtCalle.Text = cliente.Calle;
            txtAltura.Text = cliente.Altura.ToString();
            txtCodigoPostal.Text = cliente.CodPostal.ToString();
            txtTelefono.Text = cliente.NroTel;
            txtEmail.Text = cliente.Email;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals("")) {
                MessageBox.Show("No puede ingresar un cliente sin nombre");
                return;
            }
            if (txtApellido.Text.Equals(""))
            {
                MessageBox.Show("No puede ingresar un cliente sin apellido");
                return;
            }
            if (txtNombre.Text.Equals(""))
            {
                MessageBox.Show("No puede ingresar un cliente sin documento");
                return;
            }
            else if (!int.TryParse(txtNroDoc.Text, out _)) {
                MessageBox.Show("No puede ingresar letras como documento");
                return;
            }
            if (cbTipoCliente.Text.Equals("")) {
                MessageBox.Show("Debe seleccionar un tipo de cliente");
                return;
            }
            if (cbTipoDoc.Text.Equals("")) {
                MessageBox.Show("Debe seleccionar un tipo de documento");
                return;
            }
            if (txtCalle.Text.Equals("")) {
                MessageBox.Show("Debe seleccionar un tipo de documento");
                return;
            }
            if (txtAltura.Text.Equals(""))
            {
                MessageBox.Show("No puede ingresar una altura vacia");
                return;
            }
            else if (!int.TryParse(txtAltura.Text, out _))
            {
                MessageBox.Show("No puede ingresar letras como altura de direccion");
                return;
            }
            if (txtCodigoPostal.Text.Equals(""))
            {
                MessageBox.Show("No puede ingresar una codigo postal vacio");
                return;
            }
            else if (!int.TryParse(txtCodigoPostal.Text, out _))
            {
                MessageBox.Show("No puede ingresar letras como codigo postal");
                return;
            }
            if (txtTelefono.Text.Equals("") && txtEmail.Text.Equals("")) {
                MessageBox.Show("Debe ingresar un telefono o un email para poder contactarnos con usted");
                return;
            }
            oCliente.Nombre = txtNombre.Text;
            oCliente.Apellido = txtApellido.Text;
            oCliente.NombreCompleto = txtNombre.Text + txtApellido.Text;
            oCliente.Dni = txtNroDoc.Text;
            oCliente.TipoCliente.Id = Convert.ToInt16(cbTipoCliente.SelectedValue);
            oCliente.TipoDoc = Convert.ToInt16(cbTipoDoc.SelectedValue);
            oCliente.Calle = txtCalle.Text;
            oCliente.Altura = Convert.ToInt32(txtAltura.Text);
            oCliente.CodPostal = Convert.ToInt32(txtCodigoPostal.Text);
            oCliente.NroTel = txtTelefono.Text == "" ? "-":txtTelefono.Text;
            oCliente.Email = txtEmail.Text == "" ? "-" : txtEmail.Text;
            oCliente.Estado = true;

            bool save = await ActualizarCliente(oCliente);

            if (save)
            {
                MessageBox.Show("Cliente actualizado");
                this.Dispose();
            }
            else {
                MessageBox.Show("Error al actualizar");

            }
        }
        private async Task<bool> ActualizarCliente(Cliente cliente) {
            string url = "http://localhost:5197/clientes/actualizar";
            string bodyContent = JsonConvert.SerializeObject(cliente);
            var result = await ClientSingleton.ObtenerCliente().PutAsync(url,bodyContent);
            return result.Equals("true");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panelSuperior.BackColor = Color.FromArgb(51, 102, 153);
        }
        

        public void iconPictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("¿Desea cerrar pestaña?", "Saliendo formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes) this.Dispose();
        }
    }
}
