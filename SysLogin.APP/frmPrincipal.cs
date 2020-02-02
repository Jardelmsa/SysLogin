using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysLogin.APP
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmNovoUsuario frl = new frmNovoUsuario();
            frl.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin frl = new frmLogin();
            frl.Show();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            frmListaUsuarios frl = new frmListaUsuarios();
            frl.Show();
        }
    }
}
