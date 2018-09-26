using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}