using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcc_api.FornecedorApi
{
    public class Produto
    {
        public Produto[] ListaDeProdutos { get; set; }

        public Produto() { }

        public Produto(Int32? idFornecedor)
        {
            double percentual = 1.2;

            ListaDeProdutos = new Produto[]
            {
                // Extra
                new Produto()
                {
                    IdProduto = 1,
                    IdFornecedor = 1,
                    NomeProduto = "Iphone X 256gb",
                    Descricao = "O mais tecnológico smartphone da Apple",
                    Valor = 4499.99 * percentual
                },

                new Produto()
                {
                    IdProduto = 2,
                    IdFornecedor = 1,
                    NomeProduto = "Iphone 8 256gb",
                    Descricao = "Excelente smartphone da Apple",
                    Valor = 2799.99 * percentual
                },

                new Produto()
                {
                    IdProduto = 3,
                    IdFornecedor = 1,
                    NomeProduto = "Galaxy S9 128gb",
                    Descricao = "Excelente smartphone da Samsung",
                    Valor = 3499.99 * percentual
                },

                new Produto()
                {
                    IdProduto = 4,
                    IdFornecedor = 1,
                    NomeProduto = "Moto G6 Plus",
                    Descricao = "Celular de qualidade da Motorolla",
                    Valor = 999.99 * percentual
                },

                new Produto()
                {
                    IdProduto = 5,
                    IdFornecedor = 1,
                    NomeProduto = "Notebook Dell Inspiron 5000",
                    Descricao = "Notebook completo com alta performance para estudos e trabalho",
                    Valor = 1999.99 * percentual
                },

                // Submarino
                new Produto()
                {
                    IdProduto = 6,
                    IdFornecedor = 2,
                    NomeProduto = "Câmera Digital Gopro Hero 5 Black",
                    Descricao = "Gopro Hero 5 Black à prova d'água 12.1MP com Wi-Fi",
                    Valor = 1699.99 * percentual
                },

                new Produto()
                {
                    IdProduto = 7,
                    IdFornecedor = 2,
                    NomeProduto = "Moto Z3 Play",
                    Descricao = "Smartphone Motorola Moto Z3 Play Dual Chip Android Oreo - 8.0 Tela 6",
                    Valor = 2099.00 * percentual
                },

                new Produto()
                {
                    IdProduto = 8,
                    IdFornecedor = 2,
                    NomeProduto = "Galaxy A6+ Dual Chip",
                    Descricao = "Smartphone Samsung Galaxy A6+ Dual Chip Android 8.0 Tela 6",
                    Valor = 1769.99 * percentual
                },

                new Produto()
                {
                    IdProduto = 9,
                    IdFornecedor = 2,
                    NomeProduto = "Tablet Galaxy Tab A",
                    Descricao = "Tablet Samsung Galaxy Tab A 16GB Wi-Fi 4G Tela 10.1' Android",
                    Valor = 1399 * percentual
                },

                new Produto()
                {
                    IdProduto = 10,
                    IdFornecedor = 2,
                    NomeProduto = "LG G7",
                    Descricao = "Smartphone LG G7 Thinq Dual Chip Android 8.0 Tela 6.1' QHD + 64GB 4G",
                    Valor = 3099 * percentual
                },

                // Shoptime
                new Produto()
                {
                    IdProduto = 11,
                    IdFornecedor = 3,
                    NomeProduto = "Notebook Acer I7",
                    Descricao = "Notebook Acer Intel Core I7 8GB (GeForce 940MX com 2GB) 1TB Tela LED 15.6' Windows 10",
                    Valor = 2999 * percentual
                },

                new Produto()
                {
                    IdProduto = 12,
                    IdFornecedor = 3,
                    NomeProduto = "Notebook Acer Nitro",
                    Descricao = "Notebook Acer Aspire Nitro AN515-51-75KZ Intel Core i7 - 16GB (Geforce GTX 1050Ti com 4GB) 1TB Tela IPS Full HD 15,6'",
                    Valor = 4299 * percentual
                }
            };

            if (idFornecedor.HasValue && idFornecedor.Value > 0)
                ListaDeProdutos = ListaDeProdutos.Where(x => x.IdFornecedor == idFornecedor.Value).ToArray();

        }

        public Int32 IdProduto { get; set; }
        public Int32 IdFornecedor { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}