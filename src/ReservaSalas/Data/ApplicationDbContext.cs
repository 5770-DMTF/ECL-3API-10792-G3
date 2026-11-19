using Microsoft.EntityFrameworkCore;


namespace ReservaSalas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sala> Salas { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}