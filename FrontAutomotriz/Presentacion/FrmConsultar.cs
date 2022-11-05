using AutomotrizAplicacion.Datos;
using AutomotrizAplicacion.Dominio;
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
            dtpDesde.Value = DateTime.Now.AddDays(-15161);
            dtpHasta.Value = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string sp = "SP_CARGAR_FACTURAS";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@Desde", dtpDesde.Value));
            lst.Add(new Parametro("@Hasta", dtpHasta.Value));

            dgvDetalle.Rows.Clear();
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp(sp, lst);
            foreach (DataRow fila in dt.Rows)
            {
                dgvDetalle.Rows.Add(new object[] {
                    fila["idFactura"].ToString(),
                    fila["cliente"].ToString(),
                    fila["fecha"].ToString()});
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 3)
            {
                //new FrmDetallesFactura().ShowDialog();
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
