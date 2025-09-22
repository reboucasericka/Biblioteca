using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class ReservaViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Livro")]
        public int LivroId { get; set; }

        [Required]
        [Display(Name = "Leitor")]
        public string LeitorId { get; set; }

        [Display(Name = "Data da Reserva")]
        public DateTime DataReserva { get; set; } = DateTime.Now;

        [Display(Name = "Data de Expiração")]
        public DateTime? DataExpiracao { get; set; }

        [Display(Name = "Ativa?")]
        public bool Ativa { get; set; } = true;

        // Para mostrar nome do livro/leitor nas views
        public string? LivroTitulo { get; set; }
        public string? NomeLeitor { get; set; }
    }
}
