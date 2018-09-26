using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcc_UI.Helpers;

namespace tcc_UI.Models
{
    public class CheckoutModel
    {
        public CarrinhoModels Carrinho { get; set; }

        [Required(ErrorMessage = "Selecione um endereço.")]
        [DisplayName("Endereço de Entrega")]
        public int IdEndereco { get; set; }

        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Selecione uma forma de pagamento.")]
        [DisplayName("Forma de Pagamento")]
        public int TipoPagamento { get; set; }

        public List<SelectListItem> GetEnderecos(int idCliente)
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Selecione...",
                Value = "0"
            });

            var lojaApi = new LojaApi();
            var enderecos = lojaApi.ObterEnderecosCliente(idCliente);

            foreach (EnderecoModel item in enderecos)
            {
                var endereco = string.Format("{0}, {1} - Bairro {2}, {3} - {4} - CEP: {5}", item.Rua, item.Numero, item.Bairro, item.Cidade, item.Estado, item.Cep);
                list.Add(new SelectListItem
                {
                    Text = endereco,
                    Value = item.IdEndereco.ToString()
                });
            }

            return list;
        }

        public List<SelectListItem> GetTiposPagamentos()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Selecione...",
                Value = "0"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Cartão de Crédito",
                Value = "1"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Transferência Bancária",
                Value = "2"
            });

            list.Add(new SelectListItem
            {
                Selected = false,
                Text = "Boleto Bancário",
                Value = "3"
            });

            return list;
        }
    }
}