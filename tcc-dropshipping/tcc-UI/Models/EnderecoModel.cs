using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcc_UI.Models
{
    public class EnderecoModel
    {
        public int IdEndereco { get; set; }

        public int IdClienteRef { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }
    }
}