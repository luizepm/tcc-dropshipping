﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace tcc_criar_db
{
    [Table("PedidoProduto")]
    public class PedidoProduto : Manutencao
    {
        public PedidoProduto()
        {
            DtPedido = DateTime.Now;
        }

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedidoProduto { get; set; }

        [ForeignKey("Pedido")]
        public int IdPedidoRef { get; set; }
        public virtual Pedido Pedido { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdFornecedorRef { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public int IdProdutoFornecedor { get; set; }

        [Required, StringLength(100, ErrorMessage = "A nome do produto é obrigatório")]
        public string NomeProduto { get; set; }

        public string Imagem { get; set; }

        public double ValorFornecedor { get; set; }
        
        public double ValorFinal { get; set; }

        public DateTime DtPedido { get; set; }
    }
}
