using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcc_UI.Models
{
    public class StatusPedidoModel : ManutencaoModel
    {
        public StatusPedidoModel()
        {
            DtInclusao = DateTime.Now;
        }

        public int IdStatusPedido { get; set; }

        public int IdPedidoRef { get; set; }

        public string Status { get; set; }

        public DateTime DtInclusao { get; set; }
    }
}