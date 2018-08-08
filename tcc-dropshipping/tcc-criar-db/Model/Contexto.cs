using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcc_criar_db
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Tcc_Dropshipping") { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }
        public DbSet<StatusPedido> StatusPedido { get; set; }
        public DbSet<Frete> Frete { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Dominio> Dominios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        } 
    }
}
