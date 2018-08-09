using System;
using System.Collections.Generic;

namespace tcc_UI.Models
{
    public class ProdutoModels
    {
        public IEnumerable<ProdutoModels> ListaDeProdutos { get; set; }
        public Int32 IdProduto { get; set; }
        public Int32 IdFornecedor { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public Int32 Quantidade { get; set; }
    }
}