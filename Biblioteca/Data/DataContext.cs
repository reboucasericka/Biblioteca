using Biblioteca.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Biblioteca.Data
{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
       

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

    }
}
