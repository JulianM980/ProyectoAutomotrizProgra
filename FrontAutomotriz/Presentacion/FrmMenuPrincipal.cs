using AutomotrizAplicacion.Dominio;
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
    public partial class FrmMenuPrincipal : Form
    {
        private Usuario user;
        public FrmMenuPrincipal(Usuario user)
        {
            InitializeComponent();
            user = user;
        }
    }
}
