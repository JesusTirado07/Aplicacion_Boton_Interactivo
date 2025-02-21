using Microsoft.EntityFrameworkCore;

namespace Examen_Aplicativo.Models
{
    public class ExamenAplicativoContext : DbContext
    {
        public ExamenAplicativoContext(DbContextOptions<ExamenAplicativoContext> options)
            : base(options)
        {
        }

        public DbSet<Mensaje> Mensajes { get; set; }
    }
}
