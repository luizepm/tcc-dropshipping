using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tcc_UI.Models;

namespace tcc_UI.Helpers
{
    public static class Funcoes
    {
        public static string ObterCodigoPedidoCliente(int idPedido, string nome, string sobreNome)
        {
            var chavePedido = idPedido.ToString().PadLeft(5, '0');
            //var chaveData = dtPedido.Day.ToString().PadLeft(2, '0') + dtPedido.Month.ToString().PadLeft(2, '0');
            var chaveNome = nome.Substring(0, 1);
            var chaveSobrenome = sobreNome.Substring(0, 1);
            var chaveForte = Encrypt.EncryptValue(sobreNome);

            return (chaveNome + chaveSobrenome + chaveForte + chavePedido).ToUpper().Trim();
        }

        public static string ObterFormaDePagamento(int id)
        {
            var retorno = string.Empty;
            switch (id)
            {
                case 1:
                    retorno = "Cartao de Crédito";
                    break;
                case 2:
                    retorno = "Transferência Bancária";
                    break;
                case 3:
                    retorno = "Boleto Bancário";
                    break;
            }

            return retorno;
        }

        public static string ObterStatusPedido(string id)
        {
            var retorno = string.Empty;
            switch (id)
            {
                case "1":
                    retorno = "Pedido Efetuado";
                    break;
                case "2":
                    retorno = "Pagamento Autorizado";
                    break;
                case "3":
                    retorno = "Nota Fiscal Emitida";
                    break;
                case "4":
                    retorno = "Em Transporte";
                    break;
                case "5":
                    retorno = "Produto Entregue";
                    break;
            }

            return retorno;
        }
    }
}