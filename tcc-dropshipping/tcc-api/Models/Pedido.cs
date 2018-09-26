using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace tcc_api
{
    [Table("Pedido")]
    public class Pedido : Manutencao
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }

        [ForeignKey("Cliente")]
        public int IdClienteRef { get; set; }
        public virtual Cliente Cliente { get; set; }

        //[ForeignKey("Endereco")]
        public int IdEnderecoRef { get; set; }
        //public virtual Endereco Endereco { get; set; }

        public int IdFormaPagamento { get; set; }
    }
}
