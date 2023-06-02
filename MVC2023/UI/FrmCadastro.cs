using MVC2023.BLL;
using MVC2023.DAL;
using MVC2023.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC2023.UI
{
    public partial class FrmCadastro : Form
    {
        public FrmCadastro()
        {
            InitializeComponent();
            // conectar ao banco
            
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // passar os dados
            CadastrarDTO dadosCadastrar = new CadastrarDTO
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
                Senha2 = txtSenha2.Text,
                nivel = cmbNivel.Text,
            };
            // chamar o controle
            CadastrarBLL cadastrar = new CadastrarBLL();
            /* Como o método GetLoginBLL retorna
            * um booleano podemos usar ele para informar
            * o usuário se o login ocorreu ou não.
            */
            bool retorno = cadastrar.Cadastrar_BLL(dadosCadastrar);
            /*
            * Testamos se a var retorno for true
            * o login foi ok se for false deu ruim
            */
            if (retorno)
            {
                MessageBox.Show("Cadastro OK");
                // carregar o FrmMenu criando primeiro um obj
                //FrmMenu frmMenu = new FrmMenu();
                // Carregar o menu na tela
                //frmMenu.Show();
                // ocultar o FrmLogin
                //this.Hide();
            }
            else
            {
                MessageBox.Show("Erro de Cadastro");
            }
        }

        private void FrmCadastro_Load(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar = true;
            txtSenha2.UseSystemPasswordChar = true;
            var conn = utilsDAL.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    // definimos a variável sql com a query de inserção de dados
                    string sql = $"SELECT * FROM nivel";
                    // o objeto comando possui a conexão e aquery a ser executada
                    MySqlCommand comando = new MySqlCommand(sql, conn);
                    // Carregar um DataReader com MySqlComand
                    MySqlDataReader data = comando.ExecuteReader();
                    // Criar uma tabela com os dados
                    DataTable table = new DataTable();
                    // Carrega a tabela com os dados
                    table.Load(data);
                    // Informa qual o tipo dado será apresentado no combobox
                    cmbNivel.DisplayMember = "nome_nivel";
                    // Carrega os dados no combobox
                    cmbNivel.DataSource = table;
                    // Fecha a conexão com o banco
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar com o banco de dados FormCadastrarUsuario! {ex.Message}");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar == true)
            {
                txtSenha.UseSystemPasswordChar = false;
                txtSenha2.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar= true;
                txtSenha2.UseSystemPasswordChar = true;
            }
        }
    }
}
