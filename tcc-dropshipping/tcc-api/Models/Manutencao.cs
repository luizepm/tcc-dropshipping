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
    public class Manutencao
    {
        public Manutencao()
        {
            DtAtualizacao = DateTime.Now;
        }

        [Required, StringLength(10, ErrorMessage = "Usuário manutenção é obrigatório")]
        public string UsuarioManutencao { get; set; }

        public DateTime DtAtualizacao { get; set; }
    }
}
