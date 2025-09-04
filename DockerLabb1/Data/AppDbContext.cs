using Microsoft.EntityFrameworkCore;
using DockerLabb1.Models;

namespace DockerLabb1.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext
{
    public DbSet<TodoItem> Todos => Set<TodoItem>();

   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var cs =
               
                Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                
                ?? "Server=localhost;Database=LabDb;User Id=sa;Password=Your_strong@Passw0rd;TrustServerCertificate=True;Encrypt=False";

            optionsBuilder.UseSqlServer(cs);
        }
    }
}
