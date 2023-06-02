using MVC2023.DTO;
using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace MVC2023.DAL
{
    internal class CadastrarDAL
    {
        // Verificar o Login no BD
        public bool Cadastrar_DAL(CadastrarDTO dadosCadastrar)
        {
            //conectar ao BD
            // criar a conexão
            MySqlConnection conn = utilsDAL.GetConnection();
            try
            {
                // testar se deu ok na conexão
                if (conn.State == ConnectionState.Open)
                {
                    // pwesquisar o id do nível
                    string sqlId = $"select id_nivel from nivel where " +
                    $"nome_nivel = '{dadosCadastrar.nivel}'";
                    MySqlCommand retornoId = new MySqlCommand(sqlId, conn);

                    MySqlDataReader readerId = retornoId.ExecuteReader();

                    if (readerId.Read())
                    {
                        int id = (int)readerId[0];
                        readerId.Close(); // fechar / encerrar o componente pois ele carrega a conexão com o BD
                        // salvar no bd o usuario
                        string sql = $"INSERT INTO usuarios (nome, email, senha, id_nivel) " +
                        $"VALUES ('{dadosCadastrar.Nome}', " +
                        $"'{dadosCadastrar.Email}', " +
                        $"'{dadosCadastrar.Senha}', " +
                        $"'{id}')";
                        MySqlCommand retorno = new MySqlCommand(sql, conn);
                        MySqlDataReader reader = retorno.ExecuteReader();
                        // conn.Close();
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Cadastrar" + erro.Message);
                //conn.Close();
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}