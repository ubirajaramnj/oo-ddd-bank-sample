using Microsoft.EntityFrameworkCore;
using Oo.Ddd.Bank.Domain.Model;
using Oo.Ddd.Bank.Domain.Model.Factory;

namespace Oo.Ddd.Bank.Infrastructure.EntityFrameworkProvider
{
    public class BankDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        
        public DbSet<Transacao> Transacoes { get; set; }
        
        public DbSet<Agencia> Agencias { get; set; }

        public DbSet<Conta> Contas { get; set; }

        public DbSet<Especial> Especiais { get; set; }

        public BankDbContext(DbContextOptions<BankDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasKey(c => c.Id);

                c.HasMany(c => c.Documentos)
                    .WithOne()
                    .HasPrincipalKey(c => c.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                c.ToTable("Clientes");
            });
            
            modelBuilder.Entity<Documento>()
                .ToTable("Documentos")
                .HasKey(c => c.Numero);

            modelBuilder.Entity<Agencia>()
                .ToTable("Agencias")
                .HasKey(c => c.Numero);

            modelBuilder.Entity<Conta>()
                .ToTable("Contas")
                .HasKey(c => c.Numero);

            modelBuilder.Entity<Especial>()
                .ToTable("Especiais");

            modelBuilder.Entity<Transacao>()
                .ToTable("Transacoes")
                .HasKey(c => c.Id);

        }
    }
}
