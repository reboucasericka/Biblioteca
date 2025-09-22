using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class LivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(200)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório")]
        [StringLength(150)]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O ISBN é obrigatório")]
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Display(Name = "Ano de Publicação")]
        public int AnoPublicacao { get; set; }

        [Display(Name = "Imagem da Capa")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Disponível?")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Exemplares")]
        public int Stock { get; set; }
    }
}
