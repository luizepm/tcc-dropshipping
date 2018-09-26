using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tcc_UI.Models
{
    public class ManutencaoModel
    {
        public ManutencaoModel()
        {
            DtAtualizacao = DateTime.Now;
        }

        [Required]
        public string UsuarioManutencao { get; set; }

        public DateTime DtAtualizacao { get; set; }
    }
}