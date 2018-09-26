using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcc_api.FornecedorApi
{
    public class Produto
    {
        public List<Produto> ObterProdutos()
        {
            var listaFinal = new List<Produto>();
            using (var contexto = new Contexto())
            {
                var fornecedores = contexto.Fornecedores;

                foreach (var forn in fornecedores)
                {
                    var lista = ObterProdutosMockFornecedor(forn);
                    listaFinal.AddRange(lista);
                }
            }

            return listaFinal;
        }

        public Produto ObterProdutoPorId(int id)
        {
            var lista = ObterListaMockDeProduto(id, null);
            return lista != null ? lista.FirstOrDefault() : null;
        }

        public List<Produto> ObterProdutosFornecedor(string nome, string descricao, double? valorInicial, double? valorFinal)
        {
            var listaFinal = new List<Produto>();
            using (var contexto = new Contexto())
            {
                var fornecedores = contexto.Fornecedores;

                foreach (var forn in fornecedores)
                {
                    var lista = ObterProdutosMockFornecedor(forn).Where(x => x.NomeProduto.ToUpper().Trim().Contains(nome.ToUpper().Trim()));

                    if (!string.IsNullOrEmpty(descricao) && descricao != "null")
                        lista = lista.Where(x => x.Descricao.ToUpper().Trim().Contains(descricao.ToUpper().Trim()));

                    if (valorInicial.HasValue)
                        lista = lista.Where(x => x.ValorFinal >= valorInicial);

                    if (valorFinal.HasValue)
                        lista = lista.Where(x => x.ValorFinal <= valorFinal);


                    listaFinal.AddRange(lista);
                }
            }

            return listaFinal;
        }

        private List<Produto> ObterProdutosMockFornecedor(Fornecedor forn)
        {
            return ObterListaMockDeProduto(null, forn.IdFornecedor);
        }

        private List<Produto> ObterListaMockDeProduto(int? idProduto, int? idFornecedor)
        {
            double percentual = 1.2;

            var listaMock = new List<Produto>
            {
                // Extra
                new Produto()
                {
                    IdProdutoFornecedor = 1,
                    IdFornecedor = 1,
                    NomeProduto = "Iphone X 256gb",
                    Descricao = "O mais tecnológico smartphone da Apple",
                    ValorFornecedor = 4499.99,
                    ValorFinal = 4499.99 * percentual
                },

                new Produto()
                {
                    IdProdutoFornecedor = 2,
                    IdFornecedor = 1,
                    NomeProduto = "Iphone 8 256gb",
                    Descricao = "Excelente smartphone da Apple",
                    ValorFornecedor = 2799.99,
                    ValorFinal = 2799.99 * percentual
                },

                new Produto()
                {
                    IdProdutoFornecedor = 3,
                    IdFornecedor = 1,
                    NomeProduto = "Galaxy S9 128gb",
                    Descricao = "Excelente smartphone da Samsung",
                    ValorFornecedor = 3499.99,
                    ValorFinal = 3499.99 * percentual
                },

                new Produto()
                {
                    IdProdutoFornecedor = 4,
                    IdFornecedor = 1,
                    NomeProduto = "Moto G6 Plus",
                    Descricao = "Celular de qualidade da Motorolla",
                    ValorFornecedor = 999.99,
                    ValorFinal = 999.99 * percentual
                },

                new Produto()
                {
                    IdProdutoFornecedor = 5,
                    IdFornecedor = 1,
                    NomeProduto = "Notebook Dell Inspiron 5000",
                    Descricao = "Notebook completo com alta performance para estudos e trabalho",
                    ValorFornecedor = 1999.99,
                    ValorFinal = 1999.99 * percentual
                },

                new Produto()
                {
                    IdProdutoFornecedor = 7,
                    IdFornecedor = 2,
                    NomeProduto = "Moto Z3 Play",
                    Descricao = "Smartphone Motorola Moto Z3 Play Dual Chip Android Oreo - 8.0 Tela 6",
                    ValorFornecedor = 2099.00,
                    ValorFinal = 2099.00 * percentual
                },

                new Produto()
                {
                    IdProdutoFornecedor = 8,
                    IdFornecedor = 2,
                    NomeProduto = "Galaxy A6+ Dual Chip",
                    Descricao = "Smartphone Samsung Galaxy A6+ Dual Chip Android 8.0 Tela 6",
                    ValorFornecedor = 1769.99,
                    ValorFinal = 1769.99 * percentual
                },

                new Produto()
                {
                    IdProdutoFornecedor = 9,
                    IdFornecedor = 2,
                    NomeProduto = "Tablet Galaxy Tab A",
                    Descricao = "Tablet Samsung Galaxy Tab A 16GB Wi-Fi 4G Tela 10.1' Android",
                    ValorFornecedor = 1399,
                    ValorFinal = 1399 * percentual
                },

                new Produto()
                {
                    IdProdutoFornecedor = 10,
                    IdFornecedor = 2,
                    NomeProduto = "LG G7",
                    Descricao = "Smartphone LG G7 Thinq Dual Chip Android 8.0 Tela 6.1' QHD + 64GB 4G",
                    ValorFornecedor = 3099 * percentual,
                    ValorFinal = 3099 * percentual
                },

                // Shoptime
                new Produto()
                {
                    IdProdutoFornecedor = 11,
                    IdFornecedor = 3,
                    NomeProduto = "Notebook Acer I7",
                    Descricao = "Notebook Acer Intel Core I7 8GB (GeForce 940MX com 2GB) 1TB Tela LED 15.6' Windows 10",
                    ValorFornecedor = 2999 * percentual,
                    ValorFinal = 2999 * percentual
                },

                new Produto()
                {
                    IdProdutoFornecedor = 12,
                    IdFornecedor = 3,
                    NomeProduto = "Notebook Acer Nitro",
                    Descricao = "Notebook Acer Aspire Nitro AN515-51-75KZ Intel Core i7 - 16GB (Geforce GTX 1050Ti com 4GB) 1TB Tela IPS Full HD 15,6'",
                    ValorFornecedor = 4299 * percentual,
                    ValorFinal = 4299 * percentual
                }
            };

            if (idProduto.HasValue)
                listaMock = listaMock.Where(x => x.IdProdutoFornecedor == idProduto.Value).ToList();

            if (idFornecedor.HasValue)
                listaMock = listaMock.Where(x => x.IdFornecedor == idFornecedor.Value).ToList();

            return listaMock;
        }

        private List<Produto> ObterListaMockDeProdutoPorFornecedor(int idFornecedor)
        {
            return ObterListaMockDeProduto(null, idFornecedor).Where(x => x.IdFornecedor == idFornecedor).ToList();

        }

        public int IdFornecedor { get; set; }
        public int IdProdutoFornecedor { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public double ValorFornecedor { get; set; }
        public double ValorFinal { get; set; }
    }
}