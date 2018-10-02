using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tcc_UI.Models
{
    public class LoginModels
    {
        public int IdLogin { get; set; }

        [Required(ErrorMessage ="Campo obrigatório.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public ClienteModel Cliente { get; set; }

        public int Perfil { get; set; }
    }
}