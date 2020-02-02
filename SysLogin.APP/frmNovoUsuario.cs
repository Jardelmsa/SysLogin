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
using CamadaDados.DAL.Models;
using CamadaDados.DAL.Persistence;

namespace SysLogin.APP
{
    public partial class frmNovoUsuario : Form
    {
        public frmNovoUsuario()
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


        private void frmNovoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM Usuarios WHERE login= '" + txtUsuario.Text + "' ", Con);
                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    lblMensagem.Text = " Usuário já consta Registrado no Sistema! ";
                    FecharConexao();
                }
               
                else
                {
                    if(txtNomeCompleto.Text =="" || txtCPF.Text =="" || txtUsuario.Text =="" || txtSenha.Text=="" || txtConfirmarSenha.Text == "")
                    {
                        lblMensagem.Text = "Preencha todos os campos do formulário !";
                    }

                  else  if(txtSenha.Text == txtConfirmarSenha.Text)
                    {
                        Usuarios u = new Usuarios();
                        u.Nome = txtNomeCompleto.Text;
                        u.CPF = txtCPF.Text;
                        u.Login = txtUsuario.Text;
                        u.Password = txtSenha.Text;

                        UsuariosController uc = new UsuariosController();
                        uc.Create(u);

                        this.txtNomeCompleto.Text = "";
                        this.txtCPF.Text = "";
                        this.txtUsuario.Text = "";
                        this.txtSenha.Text = "";
                        this.txtConfirmarSenha.Text = "";

                        lblMensagem.Text = "Usuário " + txtUsuario.Text + "Foi Cadastrado com sucesso!";
                    }
                    else
                    {
                        lblMensagem.Text = " As Senhas não conferem !";
                        this.txtSenha.Text = "";
                        this.txtConfirmarSenha.Text = "";
                        txtSenha.Focus();

                    }
                }

            }
            catch (Exception ex)
            {

              lblMensagem.Text = ex.Message;
            }
        }
    }
}
