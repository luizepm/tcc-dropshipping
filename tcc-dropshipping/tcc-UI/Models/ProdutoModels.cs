using System;
using System.Collections.Generic;

namespace tcc_UI.Models
{
    public class ProdutoModels
    {
        public int IdProdutoFornecedor { get; set; }
        public int IdFornecedor { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public double ValorFornecedor { get; set; }
        public double ValorFinal { get; set; }
        public string Imagem { get; set; }
        public int Quantidade { get; set; }
    }
}