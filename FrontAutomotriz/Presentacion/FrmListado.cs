using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes
{
    public partial class FrmListado : Form
    {
        public FrmListado()
        {
            InitializeComponent();
        }

        private void FrmListado_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSListado.DTListado' table. You can move, or remove it, as needed.
            this.dTListadoTableAdapter.Fill(this.dSListado.DTListado);

            this.reportViewer1.RefreshReport();
        }
    }
}
