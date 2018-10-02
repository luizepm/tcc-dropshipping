using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcc_criar_db
{
    public class InicializarBd
    {
        public static void GeraTabelas(bool excluiBD, string senhaEcryptValue)
        {
            try
            {
                using (var _contexto = new Contexto())
                {
                    if (excluiBD)
                        _contexto.Database.Delete();

                    #region Criação do Cliente/Login/endereços

                    var cliente = new Cliente
                    {
                        Nome = "Luiz",
                        Sobrenome = "Moreira",
                        DtNascimento = new DateTime(1988, 11, 30),
                        Cpf = "36984511165",
                        Sexo = "M",
                        Telefone = "(11) 94545-6565",
                        UsuarioManutencao = "LUIZEDUA"
                    };

                    _contexto.Clientes.Add(cliente);

                    var login = new Login
                    {
                        Cliente = cliente,
                        Email = "luiz@teste.com",
                        Perfil = 1,
                        Senha = senhaEcryptValue,
                        UsuarioManutencao = "LUIZEDUA"
                    };

                    _contexto.Logins.Add(login);

                    var endereco1 = new Endereco
                    {
                        Cliente = cliente,
                        Rua = "Av Marechal Gonzaga",
                        Numero = 94,
                        Bairro = "Centro",
                        Cep = "09630-320",
                        Cidade = "São Caetano do Sul",
                        Estado = "SP",
                        Pais = "Brasil",
                        UsuarioManutencao = "LUIZEDUA"
                    };

                    _contexto.Enderecos.Add(endereco1);

                    #endregion

                    #region Criação dos Fornecedores e Dominios

                    var fornecedor1 = new Fornecedor
                    {
                        Nome = "SUBMARINO",
                        Cnpj = "17.538.038/0001-15",
                        URL = "http://api.hom.submarino/Produtos",
                        UsuarioApi = "Luiz-TCC-Submarino",
                        SenhaApi = Program.EncryptValue("Sub123!@#"),
                        UsuarioManutencao = "LUIZEDUA"
                    };

                    var fornecedor2 = new Fornecedor
                    {
                        Nome = "EXTRA",
                        Cnpj = "47.189.286/0001-69",
                        URL = "http://api.hom.extra/Produtos",
                        UsuarioApi = "Luiz-TCC-extra",
                        SenhaApi = Program.EncryptValue("Ext0044@#"),
                        UsuarioManutencao = "LUIZEDUA"
                    };

                    var fornecedor3 = new Fornecedor
                    {
                        Nome = "SHOPTIME",
                        Cnpj = "58.103.961/0001-01",
                        URL = "http://api.hom.shoptime/Produtos",
                        UsuarioApi = "Luiz-TCC-Shoptime",
                        SenhaApi = Program.EncryptValue("Shop567(#"),
                        UsuarioManutencao = "LUIZEDUA"
                    };

                    _contexto.Fornecedores.Add(fornecedor1);
                    _contexto.Fornecedores.Add(fornecedor2);
                    _contexto.Fornecedores.Add(fornecedor3);

                    var dominio_status1 = new Dominio { Nome = "STATUS_PEDIDO", Descricao = "PEDIDO EFETUADO", Valor = "1", UsuarioManutencao = "LUIZEDUA" };
                    var dominio_status2 = new Dominio { Nome = "STATUS_PEDIDO", Descricao = "PAGAMENTO AUTORIZADO", Valor = "2", UsuarioManutencao = "LUIZEDUA" };
                    var dominio_status3 = new Dominio { Nome = "STATUS_PEDIDO", Descricao = "NOTA FISCAL EMITIDA", Valor = "3", UsuarioManutencao = "LUIZEDUA" };
                    var dominio_status4 = new Dominio { Nome = "STATUS_PEDIDO", Descricao = "EM TRANSPORTE", Valor = "4", UsuarioManutencao = "LUIZEDUA" };
                    var dominio_status5 = new Dominio { Nome = "STATUS_PEDIDO", Descricao = "PRODUTO ENTREGUE", Valor = "5", UsuarioManutencao = "LUIZEDUA" };

                    _contexto.Dominios.Add(dominio_status1);
                    _contexto.Dominios.Add(dominio_status2);
                    _contexto.Dominios.Add(dominio_status3);
                    _contexto.Dominios.Add(dominio_status4);
                    _contexto.Dominios.Add(dominio_status5);

                    #endregion

                    #region Criação do Pedido

                    //var pedido = new Pedido
                    //{
                    //    Cliente = cliente,
                    //    IdEnderecoRef = 1,
                    //    UsuarioManutencao = "LUIZEDUA",
                    //    IdFormaPagamento = 1
                    //};

                    //_contexto.Pedidos.Add(pedido);

                    //var pedidoProduto1 = new PedidoProduto
                    //{
                    //    Pedido = pedido,
                    //    IdProdutoFornecedor = 3659,
                    //    NomeProduto = "SMARTPHONE SAMSUNG GALAXY J7 3GB/32GB",
                    //    Imagem = string.Empty,
                    //    ValorFornecedor = 799.90,
                    //    ValorFinal = ObterValorFinal(0.2, 799.90),
                    //    Fornecedor = fornecedor1,
                    //    UsuarioManutencao = "LUIZEDUA"
                    //};

                    //var pedidoProduto2 = new PedidoProduto
                    //{
                    //    Pedido = pedido,
                    //    IdProdutoFornecedor = 9966,
                    //    NomeProduto = "CARTÃO DE MEMÓRIA KINGSTON 32GB",
                    //    Imagem = string.Empty,
                    //    ValorFornecedor = 49.90,
                    //    ValorFinal = ObterValorFinal(0.2, 49.90),
                    //    Fornecedor = fornecedor2,
                    //    UsuarioManutencao = "LUIZEDUA"
                    //};

                    //_contexto.PedidoProdutos.Add(pedidoProduto1);
                    //_contexto.PedidoProdutos.Add(pedidoProduto2);

                    //var statusPedido1 = new StatusPedido
                    //{
                    //    Pedido = pedido,
                    //    Status = "1",
                    //    UsuarioManutencao = "LUIZEDUA"
                    //};

                    //var statusPedido2 = new StatusPedido
                    //{
                    //    Pedido = pedido,
                    //    Status = "2",
                    //    UsuarioManutencao = "EXTRA"
                    //};

                    //_contexto.StatusPedido.Add(statusPedido1);
                    //_contexto.StatusPedido.Add(statusPedido2);

                    //var frete = new Frete
                    //{
                    //    IdPedidoRef = pedido.IdPedido,
                    //    CodigoRastreio = "BR6645155XPTO",
                    //    DtPrevisaoEntrega = DateTime.Now.AddDays(10),
                    //    Valor = 15,
                    //    UsuarioManutencao = "LUIZEDUA"
                    //};

                    //_contexto.Frete.Add(frete);

                    #endregion

                    #region Avaliação

                    //var avaliacao = new Avaliacao
                    //{
                    //    Cliente = cliente,
                    //    PedidoProduto = pedidoProduto1,
                    //    Nota = 10,
                    //    Descricao = "Ótimo celular",
                    //    UsuarioManutencao = "LUIZEDUA"
                    //};

                    //_contexto.Avaliacao.Add(avaliacao);

                    #endregion

                    _contexto.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                }

                throw;
            }
        }

        public static double ObterValorFinal(double percentual, double valor)
        {
            return (valor * percentual) + valor;
        }

    }
}
