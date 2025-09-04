using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DockerLabb1.Data
{
    
    public class DesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            
            var cs = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                     
                     ?? "Server=localhost;Database=LabDb;User Id=sa;Password=Your_strong@Passw0rd;TrustServerCertificate=True;Encrypt=False";

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(cs)
                .Options;

            return new AppDbContext(options);
        }
    }
}
