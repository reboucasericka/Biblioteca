using Biblioteca.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    // Herda de IdentityDbContext para incluir autenticação e roles
    public class DataContext : IdentityDbContext<Leitor>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Tabelas (DbSet)
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da relação Livro ↔ Reserva
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Livro)
                .WithMany()
                .HasForeignKey(r => r.LivroId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração da relação Leitor ↔ Reserva
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Leitor)
                .WithMany()
                .HasForeignKey(r => r.LeitorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
