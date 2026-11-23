
using System.ComponentModel.DataAnnotations;

namespace ReservaSalas.Models
{
    public class Docente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ultrapassar 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Introduza um endereço de email válido.")]
        [StringLength(150, ErrorMessage = "O email não pode ultrapassar 150 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A área é obrigatória.")]
        [StringLength(100, ErrorMessage = "A área não pode ultrapassar 100 caracteres.")]
        public string Area { get; set; } = string.Empty;
    }
}
