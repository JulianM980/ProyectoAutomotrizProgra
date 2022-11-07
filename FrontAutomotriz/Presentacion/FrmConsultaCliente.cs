using Altas.Forms;
using AutomotrizAplicacion.Dominio;
using FrontAutomotriz.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAutomotriz.Presentacion
{
    public partial class FrmConsultaCliente : Form
    {
        private Cliente oCliente;
        public FrmConsultaCliente()
        {
            InitializeComponent();
            oCliente = new Cliente();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void FrmConsultaCliente_Load(object sender, EventArgs e)
        {
            await CargarClientes();
        }
        #region METODOS PRIVADOS
        private async Task  CargarClientes() {
            string url = "http://localhost:5197/clientes";
            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Cliente>>(result);
            dgvClientes.Rows.Clear();
            foreach (Cliente cliente in lst) {
                if (cliente.Estado == true) { 
                    dgvClientes.Rows.Add(new object[] {
                        cliente.NombreCompleto,
                        cliente.TipoCliente.Tipo,
                        cliente.IdCliente
                    });
                }
            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            new FrmNuevoCliente().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentCell.ColumnIndex == 3) {
                new FrmModificarCliente(Convert.ToInt16(dgvClientes.CurrentRow.Cells["colId"].Value)).ShowDialog();
            }
            if (dgvClientes.CurrentCell.ColumnIndex == 4)
            {
                DialogResult msg = MessageBox.Show("Desea dar de baja este cliente?","Eliminando cliente",MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes) {

                    bool save = await BajaDeCliente(Convert.ToInt16(dgvClientes.CurrentRow.Cells["colId"].Value));
                    if (save)
                    {
                        MessageBox.Show("Cliente dado de baja");
                        this.FrmConsultaCliente_Load(this,e);
                    }
                    else {
                        MessageBox.Show("Error al dar de baja al cliente");
                    }
                }
            }
        }
        private async Task<bool> BajaDeCliente(int id) {

            string url = $"http://localhost:5197/api/Clientes/{id}";
           var result =  await ClientSingleton.ObtenerCliente().DeleteAsync(url);
            return result.Equals("true");
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.FrmConsultaCliente_Load(this,e);
        }
    }
}
