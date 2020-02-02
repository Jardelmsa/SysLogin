using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CamadaDados.DAL.Persistence
{
    public class Conexao
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;

        protected void AbrirConexao()
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

        protected void FecharConexao()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
