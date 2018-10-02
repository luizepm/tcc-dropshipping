using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tcc_UI.Models
{
    public class EnderecoModel
    {
        public int IdEndereco { get; set; }

        public int IdClienteRef { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Pais { get; set; }

        public string ObterEndereco()
        {
            return string.Format("{0}, {1} - Bairro {2}, {3} - {4} - CEP: {5}", Rua, Numero, Bairro, Cidade, Estado, Cep);
        }

        public List<SelectListItem> GetEstados()
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
                Text = "Acre",
                Value = "AC"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Alagoas",
                Value = "AL"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Amapá",
                Value = "AP"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Amazonas",
                Value = "AM"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Bahia",
                Value = "BA"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Ceará",
                Value = "CE"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Distrito Federal",
                Value = "DF"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Espírito Santo",
                Value = "ES"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Goiás",
                Value = "GO"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Maranhão",
                Value = "MA"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Mato Grosso",
                Value = "MT"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Mato Grosso do Sul",
                Value = "MS"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Minas Gerais",
                Value = "MG"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Pará",
                Value = "PA"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Paraíba",
                Value = "PB"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Paraná",
                Value = "PR"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Pernambuco",
                Value = "PE"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Piauí",
                Value = "PI"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Rio de Janeiro",
                Value = "RJ"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Rio Grande do Norte",
                Value = "RN"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Rio Grande do Sul",
                Value = "RS"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Rondônia",
                Value = "RO"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Roraima",
                Value = "RR"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Santa Catarina",
                Value = "SC"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "São Paulo",
                Value = "SP"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Sergipe",
                Value = "SE"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Tocantins",
                Value = "TO"
            });

            return list;
        }
    }
}