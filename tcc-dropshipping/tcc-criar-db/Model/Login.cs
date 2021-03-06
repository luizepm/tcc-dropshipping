﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tcc_criar_db
{
    [Table("Login")]
    public class Login : Manutencao 
    {
        [Key, ForeignKey("Cliente")]  
        public int IdLogin { get; set; }

        [Required, StringLength(100, ErrorMessage = "O e-mail é obrigatório")]
        public string Email { get; set; }

        [Required, StringLength(100, ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }

        public int Perfil { get; set; }

        [Required]
        public virtual Cliente Cliente { get; set; }
    }
}
