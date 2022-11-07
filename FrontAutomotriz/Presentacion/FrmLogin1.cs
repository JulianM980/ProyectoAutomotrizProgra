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

            bool usuarioOk = await ConsultarCredenciales(usuario,contrasenia); 
            if (usuarioOk)
            {
                new FrmIndex().Show();
                this.Hide();
            }
            else {
                lblError.Text = "Usuario o contraseña incorrectos";
                lblError.Visible = true;
                txtContraseña.Text = "";
            }
        }
        private async Task<bool> ConsultarCredenciales(string user, string pass) {
            string url = "http://localhost:5197/credenciales/" + user + "/" + pass;

            var result = await ClientSingleton.ObtenerCliente().GetAsync(url);

            var aux = JsonConvert.DeserializeObject<bool>(result);
            return aux.Equals(true);
        }
    }
}
