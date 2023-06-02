using MVC2023.DAL;
using MVC2023.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC2023.BLL
{
    internal class CadastrarBLL
    {
        public bool Cadastrar_BLL(CadastrarDTO dadosCadastrar)
        {
            // validação
            if (VerificarNome(dadosCadastrar) && ValidarEmail(dadosCadastrar) && VerificarSenhas(dadosCadastrar) && !(dadosCadastrar.nivel == ""))
            {
                // criar um obj da DAL
                CadastrarDAL cadastrar = new CadastrarDAL();
                // chamar o logindall
                return cadastrar.Cadastrar_DAL(dadosCadastrar);

            }
            return false;
        }
        public bool VerificarNome(CadastrarDTO dadosCadastrar)
        {
            string nome = dadosCadastrar.Nome.Trim();
            Regex rgxNome = new Regex(@"^[A-Z][a-z]+\s[A-Z][a-z]+$");
            if (rgxNome.Match(nome).Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Erro!! Digite seu nome completo, com a primeira letra sendo maiscula.");
                return false;
            };
        }

        public bool ValidarEmail(CadastrarDTO dadosCadastrar)
        {
            string email = dadosCadastrar.Email.Trim();

            Regex rgxEmail = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-z]+\.[a-z]+$");
                if (rgxEmail.Match(email).Success)
                {
                    return true;
                } else {
                    MessageBox.Show("O E-mail digitado não é valido");
                    return false;
                }
        }
        public bool VerificarSenhas(CadastrarDTO dadosCadastrar)
        {
            string senha = dadosCadastrar.Senha.Trim();

            Regex rgxSenha = new Regex(@"^[A-Za-z0-9_.+--@].{7,}$");
            if (rgxSenha.Match(senha).Success)
            {
                //verifica a senha e a confirmação de senha
                if (senha == dadosCadastrar.Senha2)
                {
                    return true;
                }
                MessageBox.Show("As senhas não são iguais!");
                return false;
            }
            else
            {
                MessageBox.Show("Senha invalida, necessita de um caracter especial.");
                return false;
            }
        }
    }
}