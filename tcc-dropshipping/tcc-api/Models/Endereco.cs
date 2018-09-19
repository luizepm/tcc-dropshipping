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
    [Table("Endereco")]
    public class Endereco : Manutencao
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int IdEndereco { get; set; }

        // relacionamento 1 para muitos (incluir a FK)
        [ForeignKey("Cliente")]
        [Column(Order = 2)]
        public int IdClienteRef { get; set; }

        // Entidade da FK 1 para muitos
        public virtual Cliente Cliente { get; set; } 

        [Required, StringLength(50, ErrorMessage = "A rua é obrigatória")]
        public string Rua { get; set; }

        [Required, StringLength(50, ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        public int Numero { get; set; }

        [Required, StringLength(10, ErrorMessage = "O CEP é obrigatório")]
        public string Cep { get; set; }

        [Required, StringLength(80, ErrorMessage = "A cidadeé obrigatória")]
        public string Cidade { get; set; }

        [Required, StringLength(2, ErrorMessage = "O estado é obrigatório")]
        public string Estado { get; set; }

        [Required, StringLength(30, ErrorMessage = "O país é obrigatório")]
        public string Pais { get; set; }
    }
}
