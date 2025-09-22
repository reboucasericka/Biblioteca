using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class LeitorViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Código de Leitor")]
        public string? CodigoLeitor { get; set; }

        [Display(Name = "Foto de Perfil")]
        public string? FotoPerfilUrl { get; set; }
    }
}
