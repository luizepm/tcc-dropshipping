using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace tcc_UI.Models
{
    public class PedidoRealizadoComSucessoModel
    {
        [DisplayName("Código de Rastreio")]
        public string CodigoRastreio { get; set; }

        [DisplayName("Data prevista para entrega")]
        public string DtPrevisaoEntrega { get; set; }

        [DisplayName("Código do Pedido")]
        public string IdPedidoCliente { get; set; }
    }
}