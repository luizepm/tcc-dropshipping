using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcc_UI.Models
{
    public class PedidoProdutoModel : ManutencaoModel
    {
        public PedidoProdutoModel()
        {
            DtPedido = DateTime.Now;
        }

        public int IdPedidoProduto { get; set; }

        public int IdPedidoRef { get; set; }

        public int IdFornecedorRef { get; set; }

        public int IdProdutoFornecedor { get; set; }

        public string NomeProduto { get; set; }

        public string Imagem { get; set; }

        public double ValorFornecedor { get; set; }

        public double ValorFinal { get; set; }

        public DateTime DtPedido { get; set; }
    }
}