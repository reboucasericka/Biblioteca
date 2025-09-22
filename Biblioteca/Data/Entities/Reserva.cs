using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Entities
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Livro")]
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        [Required]
        [Display(Name = "Leitor")]
        public string LeitorId { get; set; }
        public Leitor Leitor { get; set; }

        [Display(Name = "Data da Reserva")]
        public DateTime DataReserva { get; set; } = DateTime.Now;

        [Display(Name = "Data de Expiração")]
        public DateTime? DataExpiracao { get; set; }

        [Display(Name = "Ativa?")]
        public bool Ativa { get; set; } = true;
    }
}
