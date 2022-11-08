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

namespace Reportes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string url = $"http://localhost:5197/facturas/tipoCliente/{1}";
            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<DataTable>(result);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1",lst));
            this.reportViewer1.RefreshReport();
        }
       
    }
}
