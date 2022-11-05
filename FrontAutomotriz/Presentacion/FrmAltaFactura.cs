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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altas
{
    public partial class FrmAltaFactura : Form
    {
        private Factura oFactura;
        public FrmAltaFactura()
        {
            InitializeComponent();
            oFactura = new Factura();
        }

        private void FrmAltaFactura_Load(object sender, EventArgs e)
        {
            CargarCliente();
            //CargarVendedor();
            //CargarAutoPlan();
            CargarMarcas();
            dtpFecha.Value = DateTime.Now;
            cboCliente.SelectedIndex = -1;
            cboVendedor.SelectedIndex = -1;
            cboAutoPlan.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            //ProximaFactura();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cancelar? ¡Perdera todos los datos cargados!", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation ) == DialogResult.Yes)
                this.Close();
        }

        private async void CargarCliente()
        {
            string url = "http://localhost:5197/clientes";

            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);

            var lst = JsonConvert.DeserializeObject<List<Cliente>>(result);
            cboCliente.DataSource = lst;
            cboCliente.DisplayMember = "Apellido";
            cboCliente.ValueMember = "IdCliente";
        }
        //private void CargarVendedor()
        //{
        //    cboVendedor.DataSource = HelperDB.ObtenerInstancia().ConsultarSp("SP_VENDEDOR");
        //    cboVendedor.DisplayMember = "vendedor";
        //    cboVendedor.ValueMember = "idVendedor";
        //}
        //private void CargarAutoPlan()
        //{
        //    cboAutoPlan.DataSource = HelperDB.ObtenerInstancia().ConsultarSp("SP_AUTOPLAN");
        //    cboAutoPlan.DisplayMember = "CantidadCuotas";
        //    cboAutoPlan.ValueMember = "idAutoPlan";
        //}
        private async void CargarMarcas()
        {
            string url = "http://localhost:5197/marcas";

            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);
            
            var lst = JsonConvert.DeserializeObject<List<Marca>>(result);
           
            cboMarca.DataSource = lst;
            cboMarca.DisplayMember = "Nombre";
            cboMarca.ValueMember = "IdMarca";
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            string marca = cboMarca.Text;
            string url = $"http://localhost:5197/productos/{marca}";

            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);

            var lst = JsonConvert.DeserializeObject<List<Producto>>(result);

            cboProducto.DataSource = lst;
            cboProducto.DisplayMember = "Nombre";
            cboProducto.ValueMember = "IdProducto";
            cboProducto.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cboProducto.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un PRODUCTO!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtCantidad.Text == "" || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["colProducto"].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("PRODUCTO: " + cboProducto.Text + " ya se encuentra como detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
            }

            Producto oProducto = (Producto)cboProducto.SelectedItem;//no se como hacer para que muestre el valor seleccionado 
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            DetalleDocumento detalle = new DetalleDocumento( cantidad,oProducto);
            oFactura.AgregarDetalle(detalle);
            dgvDetalle.Rows.Add(new object[] {oProducto.IdProducto, oProducto.Nombre, txtCantidad.Text, oProducto.Precio });

            CalcularTotal();
        }

        private void CalcularTotal()
        {
            double total = oFactura.CalcularTotal();
            txtTotal.Text = total.ToString();

            if (txtDescuento.Text != "")
            {
                double dto = (total * Convert.ToDouble(txtDescuento.Text)) / 100;
                txtSubTotal.Text = (total - dto).ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un producto al detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboCliente.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un cliente!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboVendedor.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un vendedor!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GuardarFactura();
        }
        private void GuardarFactura()
        {
            oFactura.Cliente = (Cliente)cboCliente.SelectedItem;
            oFactura.Descuento = Convert.ToDouble(txtDescuento.Text);
            oFactura.Fecha = dtpFecha.Value;
            oFactura.Plan = (AutoPlan)cboAutoPlan.SelectedItem;
            

            //if (HelperDB.CrearPresupuesto(oFactura))
            //{
            //    MessageBox.Show("Presupuesto registrado", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Dispose();
            //}
            //else
            //{
            //    MessageBox.Show("ERROR. No se pudo registrar el presupuesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //private void ProximaFactura()
        //{
        //    int next = HelperDB.ObtenerInstancia().ProximoPresupuesto();
        //    if (next > 0)
        //        lblNroFactura.Text = "Presupuesto Nº: " + next.ToString();
        //    else
        //        MessageBox.Show("Error de datos. No se puede obtener Nº de presupuesto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        private void btnNCliente_Click(object sender, EventArgs e)
        {
            new FrmNuevoCliente().ShowDialog();
        }

        private void btnNOrden_Click(object sender, EventArgs e)
        {
            //new FrmAltacOrden().ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
