using AutomotrizAplicacion.Dominio;
using FrontAutomotriz.Client;
using Newtonsoft.Json; 
using ProyectoAutomotriz;
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
    public partial class FrmLogin1 : Form
    {
        public FrmLogin1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasenia = txtContraseña.Text;
            string url = "http://localhost:5197/credenciales/"+usuario+"/"+contrasenia;

            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);

            var aux = JsonConvert.DeserializeObject<bool>(result);
            if (aux)
            {
                new FrmIndex().Show();
                this.Hide();
            }
            else {
                lblError.Text = "Usuario o contraseña incorrectos. Intente de nuevo";
                lblError.Visible = true;
                txtContraseña.Text = "";
            }
        }
    }
}
