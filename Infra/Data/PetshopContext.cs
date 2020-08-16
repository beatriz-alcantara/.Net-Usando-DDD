using Domain.Map;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class PetshopContext : DbContext {
        public PetshopContext(DbContextOptions options) : base(options){}

        public DbSet<Cliente> Clientes;
        public DbSet<Pet> Pets;
        public DbSet<Loja> Lojas;
        
        private void ConfigurarLoja (ModelBuilder builder) {
            builder.Entity<Loja>(entidade => {
                entidade.ToTable("Loja");
                entidade.HasKey(l => l.Id).HasName("Id");
                entidade.Property(l => l.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                entidade.Property(l => l.Nome).HasColumnName("Nome").HasMaxLength(80).IsRequired();
                entidade.Property(l => l.Descricao).HasColumnName("Descricao").HasMaxLength(200);
            });
        }

        private void ConfigurarPet(ModelBuilder builder) {
            builder.Entity<Pet>(entidade => {
                entidade.ToTable("Pet");
                entidade.HasKey(p => p.Id).HasName("Id");
                entidade.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                entidade.Property(p => p.Nome).HasColumnName("Nome").HasMaxLength(20).IsRequired();
                entidade.Property(p => p.Raca).HasColumnName("Raca").HasMaxLength(20).IsRequired();
                entidade.Property(p => p.Especie).HasColumnName("Especie").HasMaxLength(30).IsRequired();
                entidade.HasOne<Cliente>(p => p.Cliete).WithMany(c => c.Pets).HasForeignKey(p => p.ClienteId);
            });
        }

        private void ConfigurarCliente(ModelBuilder builder) {
            builder.Entity<Cliente>(entidade => {
                entidade.HasKey(c => c.Id).HasName("Id");
                entidade.Property(c => c.Id).HasColumnName("Id");
                entidade.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(60).IsRequired();
                entidade.Property(c => c.DataNascimento).HasColumnName("DataNascimento").IsRequired();
            });
        }

        private void ConfigurarRelacionamento(ModelBuilder builder) {
            builder.Entity<Relacionamento>(entidade => {});
        }
    }
}