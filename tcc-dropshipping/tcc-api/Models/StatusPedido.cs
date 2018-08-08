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
    [Table("StatusPedido")]
    public class StatusPedido : Manutencao
    {
        public StatusPedido()
        {
            DtInclusao = DateTime.Now;
        }

        [Key, ForeignKey("Pedido")]
        public Int32 IdStatusPedido { get; set; }

        [Required, StringLength(2, ErrorMessage = "O status do pedido é obrigatório")]
        public string Status { get; set; }

        public DateTime DtInclusao { get; set; }

        [Required]
        public virtual Pedido Pedido { get; set; }
    }
}
