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
    [Table("Dominio")]
    public class Dominio : Manutencao
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 IdDominio { get; set; }

        [Required, StringLength(50, ErrorMessage = "A nome do domínio é obrigatório")]
        public string Nome { get; set; }

        [Required, StringLength(50, ErrorMessage = "A descrição do domínio é obrigatória")]
        public string Descricao { get; set; }

        [Required, StringLength(30, ErrorMessage = "A valor do domínio é obrigatório")]
        public string Valor { get; set; }
    }
}
