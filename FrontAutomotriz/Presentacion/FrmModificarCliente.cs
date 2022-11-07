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
        public FrmModificarCliente(int idCliente)
        {
            InitializeComponent();
            oCliente = new Cliente();
            oCliente.IdCliente = idCliente;
        }
        private async void FrmModificarCliente_Load(object sender, EventArgs e)
        {
            await CargarTiposClientes();
            await CargarTiposDocumentos();
            await CargarCliente(oCliente.IdCliente);
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
    }
}
