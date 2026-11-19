namespace ReservaSalas.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public int DocenteId { get; set; }
        public DateOnly Data { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
        public string Finalidade { get; set; }

        public Sala Sala { get; set; } = null!;
        public Docente Docente { get; set; } = null!;
    }
}