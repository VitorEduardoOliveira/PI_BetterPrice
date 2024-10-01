using BetterPrice.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetterPrice.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
            builder.Entity<Produto>(produto =>
            {
                produto.HasKey(p => p.Id);
                produto.Property(p => p.Id).ValueGeneratedOnAdd();

                produto.HasOne(p => p.Categoria);
                produto.HasOne(p => p.Departamento);
            });

            builder.Entity<Mercado>(mercado =>
            {
                mercado.HasKey(m => m.Id);
                mercado.Property(m => m.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<ItemPreco>(itemPreco =>
            {
                itemPreco.HasKey(i => i.Id);
                itemPreco.Property(i => i.Id).ValueGeneratedOnAdd();

                builder.Entity<ItemPreco>().HasOne(i => i.Produto);
                builder.Entity<ItemPreco>().HasOne(i => i.Mercado);
            });

        }
    }
}
