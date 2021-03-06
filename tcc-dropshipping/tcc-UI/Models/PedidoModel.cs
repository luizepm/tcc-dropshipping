﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcc_UI.Models
{
    public class PedidoModel : ManutencaoModel
    {
        public int IdPedido { get; set; }

        public int IdClienteRef { get; set; }

        public int IdEnderecoRef { get; set; }
        
        public int IdFormaPagamento { get; set; }

        public List<ProdutoModels> Itens { get; set; }
        public List<StatusPedidoModel> StatusPedido { get; set; }
        public FreteModel Frete { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}