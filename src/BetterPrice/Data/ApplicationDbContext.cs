using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemPreco> ItemPrecos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Usuario
            builder.Entity<Usuario>(usuario =>
            {
                usuario.HasKey(i => i.Id);
                usuario.Property(i => i.Id).ValueGeneratedOnAdd();

                // One-to-One relationship with Carrinho (CarrinhoId will be set in Carrinho entity)
                usuario.HasOne(u => u.Carrinho)
                    .WithOne(c => c.Usuario)
                    .HasForeignKey<Carrinho>(c => c.UsuarioId);
            });

            // Mercado
            builder.Entity<Mercado>(mercado =>
            {
                mercado.HasKey(m => m.Id);
                mercado.Property(m => m.Id).ValueGeneratedOnAdd();
            });
            builder.MercadosPadroes();

            // Categoria
            builder.Entity<Categoria>(categoria =>
            {
                categoria.HasKey(c => c.Id);
                categoria.Property(c => c.Id).ValueGeneratedOnAdd();
            });
            builder.CategoriasPadroes();

            // Departamento
            builder.Entity<Departamento>(departamento =>
            {
                departamento.HasKey(d => d.Id);
                departamento.Property(d => d.Id).ValueGeneratedOnAdd();
            });
            builder.DepartamentosPadroes();

            // Produto
            builder.Entity<Produto>(produto =>
            {
                produto.HasKey(p => p.Id);
                produto.Property(p => p.Id).ValueGeneratedOnAdd();

                produto.HasOne(p => p.Categoria);
                produto.HasOne(p => p.Departamento);
            });
            builder.ProdutosPadroes();

            //Preco
            builder.Entity<ItemPreco>(itemPreco =>
            {
                itemPreco.HasKey(i => i.Id);
                itemPreco.Property(i => i.Id).ValueGeneratedOnAdd();

                builder.Entity<ItemPreco>().HasOne(i => i.Produto);
                builder.Entity<ItemPreco>().HasOne(i => i.Mercado);
            });
            builder.PrecosPadroes();

            //Carrinho
            builder.Entity<Carrinho>(carrinho =>
            {
                carrinho.HasKey(c => c.Id);

                carrinho.HasOne(c => c.Usuario)
                    .WithOne(u => u.Carrinho)
                    .HasForeignKey<Carrinho>(c => c.UsuarioId);

                carrinho.HasMany(c => c.Items);
            });
        }
    }
}
