using System.ComponentModel.DataAnnotations;

namespace ReservaSalas.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A sala é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione uma sala válida.")]
        public int SalaId { get; set; }

        [Required(ErrorMessage = "O docente é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione um docente válido.")]
        public int DocenteId { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateOnly Data { get; set; }

        [Required(ErrorMessage = "A hora de início é obrigatória.")]
        public TimeOnly HoraInicio { get; set; }

        [Required(ErrorMessage = "A hora de fim é obrigatória.")]
        public TimeOnly HoraFim { get; set; }

        [Required(ErrorMessage = "A finalidade é obrigatória.")]
        [StringLength(255, ErrorMessage = "A finalidade não pode ultrapassar 255 caracteres.")]
        public string Finalidade { get; set; } = string.Empty;

        public Sala? Sala { get; set; }
        public Docente? Docente { get; set; }
    }
}
