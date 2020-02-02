using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CamadaDados.DAL.Models;

namespace CamadaDados.DAL.Persistence
{
    public class UsuariosController : Conexao
    {
        public void Create(Usuarios u)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("INSERT INTO Usuarios VALUES (@v1, @v2, @v3, @v4)", Con);
                Cmd.Parameters.AddWithValue("@v1", u.Nome);
                Cmd.Parameters.AddWithValue("@v2", u.CPF);
                Cmd.Parameters.AddWithValue("@v3", u.Login);
                Cmd.Parameters.AddWithValue("@v4", u.Password);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
