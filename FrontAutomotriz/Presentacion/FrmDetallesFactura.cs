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
    public partial class FrmDetallesFactura : Form
    {
        private Factura oFactura;
        public FrmDetallesFactura(int id)
        {
            InitializeComponent();
            oFactura = new Factura();
            oFactura.IdFactura = id;
        }

        private async void FrmDetallesFactura_Load(object sender, EventArgs e)
        {
             await CargarFactura();
            dgvDetalle.ClearSelection();
        }
        #region METODOS PRIVADOS
        private async Task<Factura> RecuperarFactura(int id) {
            string url = $"http://localhost:5197/factura/{id}";

            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);

            var factura = JsonConvert.DeserializeObject<Factura>(result);
            return factura;
        }
        private async Task CargarFactura() {
            Factura factura = await RecuperarFactura(oFactura.IdFactura);

            dtpFecha.Value = factura.Fecha;
            cboCliente.Text = factura.Cliente.NombreCompleto;
            cboVendedor.Text = factura.Vendedor.NombreCompleto;
            if (factura.Plan.IdAutoPlan == 1) rbPlan1.Checked = true;
            if (factura.Plan.IdAutoPlan == 2) rbPlan2.Checked = true;
            if (factura.Plan.IdAutoPlan == 3) rbPlan3.Checked = true;
            txtDescuento.Text = factura.Descuento.ToString();

            dgvDetalle.Rows.Clear();
            foreach (DetalleDocumento dd in factura.DetallesFactura) {
                dgvDetalle.Rows.Add(new object[] { 
                    dd.Producto.Nombre,
                    dd.Cantidad,
                    dd.Producto.Precio,
                    dd.Producto.IdProducto
                });
            }
            CalcularTotal(factura);

        }
        private void CalcularTotal(Factura f)
        {
            double total = f.CalcularTotal();
            txtSubTotal.Text = total.ToString();

            if (txtDescuento.Text != "")
            {
                double dto = (total * Convert.ToDouble(txtDescuento.Text)) / 100;
                txtTotal.Text = (total - dto).ToString();
            }
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void rbPlan1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
