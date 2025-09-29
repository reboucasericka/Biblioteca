using Biblioteca.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class DataContext : IdentityDbContext<Leitor>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
                   
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Configurar relacionamentos
            builder.Entity<Reserva>()
                .HasOne(r => r.Livro)
                .WithMany()
                .HasForeignKey(r => r.LivroId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Reserva>()
                .HasOne(r => r.Leitor)
                .WithMany()
                .HasForeignKey(r => r.LeitorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
