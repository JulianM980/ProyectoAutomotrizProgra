using AutomotrizAplicacion.Dominio;
using FrontAutomotriz.Client;
using Newtonsoft.Json;
using System.Data;

namespace Reportes
{
    public partial class FrmReporte : Form
    {
        public FrmReporte()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarTiposClientes();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(cbTipoCliente.SelectedValue);
            string url = $"http://localhost:5197/clientesTipo/{id}";
            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Cliente>>(result);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", lst));
            this.reportViewer1.RefreshReport();
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

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
