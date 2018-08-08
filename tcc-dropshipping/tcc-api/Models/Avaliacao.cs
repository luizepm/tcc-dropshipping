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
    [Table("Avaliacao")]
    public class Avaliacao : Manutencao
    {
        public Avaliacao()
        {
            DtInclusao = DateTime.Now;
        }

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 IdAvaliacao { get; set; }

        [Required, StringLength(300, ErrorMessage = "A nome do produto é obrigatório")]
        public string Descricao { get; set; }

        public Int32 Nota { get; set; }

        public DateTime DtInclusao { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual PedidoProduto PedidoProduto { get; set; }
    }
}
