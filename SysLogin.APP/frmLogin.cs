using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SysLogin.APP
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

     
        SqlConnection Con;
        SqlCommand Cmd;
        SqlDataReader Dr;

        private void AbrirConexao()
        {
            try
            {
                Con = new SqlConnection("DATA SOURCE=DESKTOP-6NKVMJU; Initial Catalog=SysLogin; Integrated Security=True;");
                Con.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void FecharConexao()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtSenha.Text == "")
            {
                lblMensagem.Text = "Preencha os campos do formulário";

            }
            else
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM Usuarios WHERE login= '" + txtUsuario.Text + "' AND password= '" + txtSenha.Text + "' ", Con);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    this.Visible=false;
                    frmPrincipal frl = new frmPrincipal();
                    frl.Show();
                    FecharConexao();
                    ;
                }
                else
                {
                    lblMensagem.Text = " Nome de usuário ou senha não existem";
                    this.txtSenha.Text = "";
                    this.txtUsuario.Text = "";
                }

            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
