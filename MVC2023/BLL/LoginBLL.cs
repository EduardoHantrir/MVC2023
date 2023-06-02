using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC2023.DAL;
using MVC2023.DTO;

namespace MVC2023.BLL
{
    internal class LoginBLL
    {
        // Metodo de controle
        public bool GetLoginBLL(LoginDTO DadosLogin)
        {   
            // Validação
            if (DadosLogin.Email == "" || DadosLogin.Senha =="")
            {
                return false;
            }

            // criar um obj da DAL
            LoginDAL login = new LoginDAL();
            // chamar o logindall
            return login.GetLoginDAL(DadosLogin);

        }
    }
}
