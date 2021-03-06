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
    [Table("Frete")]
    public class Frete : Manutencao
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFrete { get; set; }

        [Required, StringLength(20, ErrorMessage = "O código para rastreio do pedido é obrigatório")]
        public string CodigoRastreio { get; set; }

        public DateTime DtPrevisaoEntrega { get; set; }

        public double Valor { get; set; }

        [ForeignKey("Pedido")]
        public int IdPedidoRef { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
