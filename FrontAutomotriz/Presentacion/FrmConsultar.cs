using AutomotrizAplicacion.Datos;
using AutomotrizAplicacion.Dominio;
using FrontAutomotriz.Client;
using FrontAutomotriz.Presentacion;
using Newtonsoft.Json;
using RecetasSLN.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altas.Consultar
{
    public partial class FrmConsultar : Form
    {
        public FrmConsultar()
        {
            InitializeComponent();
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {
            
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            string anio = txtAnio.Text;
            string url = $"http://localhost:5197/facturas/{anio}";

            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);

            var lst = JsonConvert.DeserializeObject<List<Factura>>(result);

            dgvDetalle.Rows.Clear();
            foreach (Factura fila in lst)
            {
                dgvDetalle.Rows.Add(new object[] {
                    fila.IdFactura,
                    fila.Cliente.NombreCompleto,
                    fila.Fecha});
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 3)
            {
                new FrmDetallesFactura(Convert.ToInt16(dgvDetalle.CurrentRow.Cells["ColFactura"].Value)).ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
