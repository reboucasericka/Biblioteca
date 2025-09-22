using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Entities
{
    public class Livro
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Titulo { get; set; }

        [Required, StringLength(150)]
        public string Autor { get; set; }

        // Aceita ISBN-10 ou ISBN-13
        [Required, StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Display(Name = "Ano de Publicação")]
        public int AnoPublicacao { get; set; }

        [Display(Name = "Capa do Livro")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Disponível?")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Exemplares em Stock")]
        public int Stock { get; set; } = 1;

        [Display(Name = "Data de Adição")]
        public DateTime DataAdicao { get; set; } = DateTime.Now;

        [Display(Name = "Última Reserva")]
        public DateTime? DataUltimaReserva { get; set; }
    }
}
