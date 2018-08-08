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
        public Int32 IdPedido { get; set; }

        //[ForeignKey("Cliente")]
        //[Column(Order = 2)]
        //public Int32 IdCliente { get; set; }

        //[ForeignKey("Fornecedor")]
        //[Column(Order = 3)]
        //public Int32 IdFornecedor { get; set; }

        //[ForeignKey("Endereco")]
        //public Int32 IdEndereco { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
