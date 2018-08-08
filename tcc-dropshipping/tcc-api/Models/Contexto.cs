using System.Data.Entity;

namespace tcc_api
{
    public class Contexto : DbContext
    {
        public Contexto() : base("tcc_dropshipping") 
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

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
