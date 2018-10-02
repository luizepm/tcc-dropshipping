using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tcc_UI.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Data de Nascimento")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DtNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Telefone { get; set; }

        public List<EnderecoModel> Enderecos { get; set; }

        public string ObterDataNascimento()
        {
            return DtNascimento.ToString("dd/MM/yyyy");
        }

        public string ObterDescricaoSexo()
        {
            return Sexo == "M" ? "Masculino" : "Feminino";
        }

        public string ObterCPFFormatado()
        {
            return Convert.ToUInt64(Cpf).ToString(@"000\.000\.000\-00");
        }

        public string ObterNomeUsuario()
        {
            var nomeCompleto = Nome + Sobrenome;
            return nomeCompleto.Substring(0, 8).Trim().ToUpper();
        }

        public string ObterNomeCompleto()
        {
            return Nome + " " + Sobrenome;
        }

        public List<SelectListItem> GetSexos()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Selecione...",
                Value = ""
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Feminino",
                Value = "F"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Masculino",
                Value = "M"
            });

            return list;
        }
    }
}