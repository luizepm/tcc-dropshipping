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
    [Table("Fornecedor")]
    public class Fornecedor : Manutencao
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 IdFornecedor { get; set; }

        [Required, StringLength(80, ErrorMessage = "A nome do fornecedor é obrigatório")]
        public string Nome { get; set; }

        [Required, StringLength(20, ErrorMessage = "O CNPJ é obrigatório")]
        public string Cnpj { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
