using MVC2023.BLL;
using MVC2023.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVC2023.UI;

namespace MVC2023
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Passar os dados
            LoginDTO DadosLogin = new LoginDTO
            {
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
            };

            // Chamar os controles
            LoginBLL loginBLL = new LoginBLL();

            loginBLL.GetLoginBLL(DadosLogin);

            bool retorno = loginBLL.GetLoginBLL(DadosLogin);
            
            if (retorno)
            {
                FrmMenu frmMenu = new FrmMenu();

                frmMenu.Show();

                this.Hide();
            } else
            {
                MessageBox.Show("Não foi possivel realizar o Login, tente novamente!");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar == true)
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar= true;
        }
    }
}
