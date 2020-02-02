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
    public partial class frmListaUsuarios : Form
    {
        public frmListaUsuarios()
        {
            InitializeComponent();
        }
        private void TotalRegistros()
        {
            lblTotal.Text = "Total de Registros: " + dgvUsuarios.RowCount;
        }
        SqlConnection Con;
        SqlCommand Cmd;
        SqlDataReader Dr;
        SqlDataAdapter Adpt;

        private void CarregarGrid()
        {
            try
            {
                AbrirConexao();
                DataTable dt = new DataTable();
                Adpt = new SqlDataAdapter("SELECT  id, nome_completo, cpf, login FROM Usuarios", Con);
                Adpt.Fill(dt);
                dgvUsuarios.DataSource = dt;
                FecharConexao();

            }
            catch (Exception ex)  
            {

                throw new Exception(ex.Message);
            }
        }
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

        private void frmListaUsuarios_Load(object sender, EventArgs e)
        {
            
            CarregarGrid();
            TotalRegistros();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtBuscar.Text == "")
                {
                    MessageBox.Show(" Digite o Login do CPF do Usuário!");
                }
                else
                {
                    AbrirConexao();
                    DataTable dt = new DataTable();
                    Adpt = new SqlDataAdapter("SELECT  id, nome_completo, cpf, login FROM Usuarios WHERE cpf= '" + txtBuscar.Text + "' ", Con);
                    Adpt.Fill(dt);
                    dgvUsuarios.DataSource = dt;
                    TotalRegistros();
                    FecharConexao();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.txtBuscar.Text = "";
            CarregarGrid();
            TotalRegistros();
        }
    }
}
