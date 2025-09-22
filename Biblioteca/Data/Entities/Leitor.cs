using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Biblioteca.Data.Entities
{
    // Integra com Identity (AspNetUsers)
    public class Leitor : IdentityUser
    {
        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Código de Leitor")]
        public string? CodigoLeitor { get; set; }

        [Display(Name = "Foto de Perfil")]
        public string? FotoPerfilUrl { get; set; }

        // Navegação opcional (não é obrigatório usar)
        public ICollection<Reserva>? Reservas { get; set; }
    }
}
