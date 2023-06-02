using MVC2023.DTO;
using MVC2023.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows.Forms;
using System.Data;

namespace MVC2023.DAL
{
    internal class LoginDAL
    {
        // Verificar o Login no BD
        public bool GetLoginDAL(LoginDTO DadosLogin)
        {
            // Usar o TRY, CATCH para tentar se conectar ao banco
            try
            {
                // Criar a conexão
                MySqlConnection conn = utilsDAL.GetConnection();

                if (conn.State == ConnectionState.Open)
                {
                    string sql = $"SELECT * FROM usuarios" +
                                 $"WHERE" +
                                 $"email = '{DadosLogin.Email}'" +
                                 $"AND" +
                                 $"senha = '{DadosLogin.Senha}'";

                    MySqlCommand retorno = new MySqlCommand(sql, conn);

                    MySqlDataReader reader = retorno.ExecuteReader();

                    if (reader.Read())
                    {   
                        conn.Close();
                        return true;
                    }
                    
                    conn.Close();
                    return false;

                }
            } catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                return false;
            }
            return false;
        }
    }
}
