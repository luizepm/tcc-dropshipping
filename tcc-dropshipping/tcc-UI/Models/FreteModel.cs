using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcc_UI.Models
{
    public class FreteModel : ManutencaoModel
    {
        public int IdFrete { get; set; }

        public string CodigoRastreio { get; set; }

        public DateTime DtPrevisaoEntrega { get; set; }

        public double Valor { get; set; }

        public int IdPedidoRef { get; set; }
    }
}