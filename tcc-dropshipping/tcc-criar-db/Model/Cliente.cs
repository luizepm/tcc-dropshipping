using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tcc_criar_db
{
    [Table("Cliente")]
    public class Cliente : Manutencao
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public Int32 IdCliente { get; set; }

        [Required, StringLength(50, ErrorMessage = "O nome do cliente é obrigatório")]
        public string Nome { get; set; }

        [Required, StringLength(50, ErrorMessage = "O sobrenome do cliente é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DtNascimento { get; set; }

        [Required, StringLength(20, ErrorMessage = "O CPF é obrigatório")]
        public string Cpf { get; set; }
        
        [Required, StringLength(1, ErrorMessage = "Informe apenas M ou F")]
        public string Sexo { get; set; }

        [Required, StringLength(20, ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        public virtual Login Login { get; set; }
        
        // relacionamento 1 para muitos (incluir a FK na tabela de endereço)
        public virtual ICollection<Endereco> Enderecos { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
