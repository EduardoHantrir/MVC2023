using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC2023.DTO
{
    internal class CadastrarDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string Senha2 { get; set; }
        public string nivel { get; set; }

        public bool GetNome(string Nome)
        {
            //Regex
            this.Nome = Nome;
            return true;
        }
    }
}
