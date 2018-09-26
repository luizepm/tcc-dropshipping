using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcc_UI.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime DtNascimento { get; set; }

        public string Cpf { get; set; }

        public string Sexo { get; set; }

        public string Telefone { get; set; }

        public string ObterNomeUsuario()
        {
            var nomeCompleto = Nome + Sobrenome;
            return nomeCompleto.Substring(0, 8).Trim().ToUpper();
        }

        public string ObterNomeCompleto()
        {
            return Nome + " " + Sobrenome;
        }
    }
}