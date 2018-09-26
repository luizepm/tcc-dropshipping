using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace tcc_criar_db
{
    [Table("Pedido")]
    public class Pedido : Manutencao
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }

        [ForeignKey("Cliente")]
        public int IdClienteRef { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int IdEnderecoRef { get; set; }

        public int IdFormaPagamento { get; set; }
    }
}
