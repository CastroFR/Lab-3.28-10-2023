using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Evaluaciones> evaluaciones { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-GGOC9T3P;Database=lab3; Trusted_Connection = SSPI; MultipleActiveResultSets = true ");
    }

}
