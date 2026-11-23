
using System.ComponentModel.DataAnnotations;

namespace ReservaSalas.Models
{
    public class Sala
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O código é obrigatório.")]
        [StringLength(20, ErrorMessage = "O código não pode ultrapassar 20 caracteres.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A capacidade é obrigatória.")]
        [Range(1, 50, ErrorMessage = "A capacidade tem de ser superior a 0 e inferior a 50.")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tipo não pode ultrapassar 50 caracteres.")]
        public string Tipo { get; set; } = string.Empty;
    }
}
